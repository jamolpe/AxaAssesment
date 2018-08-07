import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import { RingLoader } from 'react-spinners';

interface TokenStateModel {
    isWaitingResponse: boolean;
    recivedResponse: boolean;
    responseresult: string;
    buttonText:string;
}
interface ResponseToken {
    token:string;
}

export class TokenCaller extends React.Component<RouteComponentProps<{}>, TokenStateModel>
{
    constructor() {
        super();
        this.state = { isWaitingResponse: false, recivedResponse: false, responseresult: '', buttonText:'Get my token!'};
        this.CallTokenGenerator = this.CallTokenGenerator.bind(this);
    }
    public render() {
        return (<div>
                    <h1>Obtain your token</h1>
                    <label>Your User Name</label>
                    <input className="form-control"/>
                    <label>Your User Id *</label>
                    <input className="form-control"/>
            <small id="emailHelp" className="form-text text-muted">*Leave this blank if you are not a user from our Data Base.You will only have access to certain data</small>
            {this.ElementByState()}
           </div>);
    }

    ElementByState() {
        if (this.state.isWaitingResponse) {
            return <RingLoader
                color={'#123abc'}
                loading={this.state.isWaitingResponse}
            />
        } else if (this.state.recivedResponse) {
            return <div><div>{this.state.responseresult}</div>
                <button onClick={this.CallTokenGenerator} className="btn btn-success token-button"> {this.state.buttonText} </button></div>
        } else {
            return <button onClick={this.CallTokenGenerator} className="btn btn-success token-button"> {this.state.buttonText} </button>
        }
    }

    CallTokenGenerator() {
        this.setState({ isWaitingResponse: true });
        var settings = {
            "async": true,
            "crossDomain": true,
            "url": "http://localhost:58939/api/security/token",
            "method": "POST",
            "headers": {
                "content-type": "application/json",
                "cache-control": "no-cache",
                "postman-token": "40994a3a-31f1-d35e-41a8-5f8556f886f8"
            },
            "processData": false,
            "data": "{\n\t\"Username\" : \"Test\",\n\t\"UserId\" : \"a3b8d425-2b60-4ad7-becc-bedf2ef860bd\",\n\t\"IsThirdParties\":true\n}"
        }
        fetch('api/security/token', settings)
            .then(response => response.json() as Promise<ResponseToken>)
            .then(data => {
                this.setState({ responseresult: data.token, isWaitingResponse: false, recivedResponse: true, buttonText:'Get new token'});
                console.log(this.state);
            });
    }
    
}
