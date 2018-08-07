import * as React from 'react';
import { Link, NavLink } from 'react-router-dom';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';

interface TopBarMobile {
    textclass: string;
}

export class TopBar extends React.Component<{}, TopBarMobile> {
    constructor() {
        super();
        this.state = { textclass: 'top-bar' };
    }

    public render() {
        return (<div className={this.state.textclass} id="myTopnav">
                    <div>
                        <NavLink to={'/'} exact activeClassName='active'>
                            <span>Home</span>
                        </NavLink>
                        <NavLink to={'/tokenMaker'} exact activeClassName='active'>
                            <span>your token</span>
                        </NavLink>
                        <a className="icon" onClick={() => {
                            if (this.state.textclass.indexOf(' responsive') == -1) {
                                this.setState({ textclass: this.state.textclass + ' responsive' });
                            } else {
                                this.setState({ textclass: 'top-bar' })
                            }
                            console.log(this.state)
                        }}>
                            <FontAwesomeIcon icon="bars"/>
                        </a>
                    </div>
                </div>);
    }
}