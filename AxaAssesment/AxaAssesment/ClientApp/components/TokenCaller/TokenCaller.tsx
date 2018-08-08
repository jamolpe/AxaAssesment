import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import { RingLoader } from 'react-spinners';

interface TokenStateModel {
    isWaitingResponse: boolean;
    recivedResponse: boolean;
    responseresult: string;
    buttonText: string;
    userName: string;
    userId: string;
    isThirdParties:boolean;
}
interface ResponseToken {
    token:string;
}

export class TokenCaller extends React.Component<RouteComponentProps<{}>, TokenStateModel>
{
    constructor() {
        super();
        this.state = {
            isWaitingResponse: false,
            recivedResponse: false,
            responseresult: '',
            buttonText: 'Get my token!',
            userName: '',
            userId: '',
            isThirdParties: false
    };
        this.CallTokenGenerator = this.CallTokenGenerator.bind(this);
    }
    public render() {
        return (<div>
                    <h1>Get your token</h1>
                    <label>Your User Name</label>
                    <small id="emailHelp" className="form-text text-muted"> *Required</small>
                         <input className={this.state.userName != '' ? "form-control" : "form-control error"} value={this.state.userName} onChange={e => this.setState({ userName: e.target.value })} />
                    <label>Your User Id *</label>
                         <input className="form-control" value={this.state.userId} onChange={e => this.setState({ userId: e.target.value })} />
                    <small id="emailHelp" className="form-text text-muted">*Leave this blank if you are not a user from our Data Base.You will only have access to certain data</small>
                    {this.ElementByState()}
           </div>);
    }

    ElementByState() {
        if (this.state.isWaitingResponse) {
            return <div className="loader">
                       <RingLoader
                           color={'#123abc'}
                           loading={this.state.isWaitingResponse}
                       /></div>
        } else if (this.state.recivedResponse) {
            return <div><button disabled={this.state.userName == ''} onClick={this.CallTokenGenerator} className="btn btn-success token-button"> {this
                .state.buttonText} </button>
                    <div className="result-Box">{this.state.responseresult}</div>
                </div>
        } else {
            return <button onClick={this.CallTokenGenerator} disabled={this.state.userName == ''} className="btn btn-success token-button"> {this.state
                .buttonText} </button>
        }
    }

    CallTokenGenerator() {
        if (this.state.userId == '') {
            this.setState({ isThirdParties: true });
        } else {
            this.setState({ isThirdParties: false });
        }
        this.setState({ isWaitingResponse: true });
        var data = {
            Username: this.state.userName,
            UserId: this.state.userId,
            IsThirdParties: this.state.isThirdParties
        }
        var settings = {
            "method": "POST",
            "headers": {
                "content-type": "application/json",
            },
            "processData": false,
            "body": JSON.stringify(data)
        }
        let resStatus = 0;
        fetch('api/security/token', settings)
            .then(response => {
                resStatus = response.status;
                return response.json() as Promise<ResponseToken>
             })
            .then(data => {
                switch (resStatus) {
                    case 200:
                        this.setState({
                            responseresult: data.token,
                            isWaitingResponse: false,
                            recivedResponse: true,
                            buttonText: 'Get new token'
                        });
                        break;
                    case 400:
                        this.setState({
                            responseresult: 'An error ocurred please check the User Name ',
                            isWaitingResponse: false,
                            recivedResponse: true,
                            buttonText: 'Try again'
                        });
                        break;
                    
                default:
                }
            });

    }
    
}
