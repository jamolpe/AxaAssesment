import * as React from 'react';
import { Route } from 'react-router-dom';
import { Home } from './components/Home';
import { MainBody } from './components/MainBody';
import { TokenCaller } from './components/TokenCaller/TokenCaller';

export const routes = <MainBody>
    <Route exact path='/' component={ Home } />
    <Route path='/tokenMaker' component={ TokenCaller } />
</MainBody>;
