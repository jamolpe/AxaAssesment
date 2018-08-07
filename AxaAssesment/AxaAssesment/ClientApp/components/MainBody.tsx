import * as React from 'react';
import { DownAbout } from './DownAbout/DownAbout';
import { TopBar } from './TopBar/TopBar';


export interface LayoutProps {
    children?: React.ReactNode;
}

export class MainBody extends React.Component<LayoutProps, {}> {
    public render() {
        return (
            <div>
                <TopBar />
                <div className = "main-body">
                    { this.props.children }
                        <DownAbout />
                    </div>
            </div>
           );

    }
} 