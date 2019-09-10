import React, { Component, Fragment } from 'react';
import authService from './AuthorizeService';
import { ApplicationPaths } from './ApiAuthorizationConstants';
import Link from '@material-ui/core/Link';
import { createMuiTheme } from '@material-ui/core/styles';


export class LoginMenu extends Component {
    constructor(props) {
        super(props);

        this.state = {
            isAuthenticated: false,
            userName: null
        };
    }

    componentDidMount() {
        this._subscription = authService.subscribe(() => this.populateState());
        this.populateState();
    }

    componentWillUnmount() {
        authService.unsubscribe(this._subscription);
    }

    async populateState() {
        const [isAuthenticated, user] = await Promise.all([authService.isAuthenticated(), authService.getUser()])
        this.setState({
            isAuthenticated,
            userName: user && user.name
        });
    }

    render() {
        const { isAuthenticated, userName } = this.state;
        if (!isAuthenticated) {
            const registerPath = `${ApplicationPaths.Register}`;
            const loginPath = `${ApplicationPaths.Login}`;
            return this.anonymousView(registerPath, loginPath);
        } else {
            const profilePath = `${ApplicationPaths.Profile}`;
            const logoutPath = { pathname: `${ApplicationPaths.LogOut}`, state: { local: true } };
            return this.authenticatedView(userName, profilePath, logoutPath);
        }
    }

    authenticatedView(userName, profilePath, logoutPath) {
        const theme = createMuiTheme();
        return (<Fragment>
            <nav>
                <Link variant="button" tag={Link} color="textPrimary" style={{ margin: theme.spacing(1, 1.5) }}
                    href={profilePath}>Hello {userName}</Link>
                <Link variant="button" tag={Link} color="textPrimary" style={{ margin: theme.spacing(1, 1.5) }}
                    href={logoutPath}>Logout </Link>
            </nav>
        </Fragment>);

    }

    anonymousView(registerPath, loginPath) {
        const theme = createMuiTheme();
        return (<Fragment>
            <nav>
                <Link variant="button" tag={Link} color="textPrimary" style={{ margin: theme.spacing(1, 1.5) }}
                    href={registerPath}>Register</Link>
                <Link variant="button" tag={Link} color="textPrimary" style={{ margin: theme.spacing(1, 1.5) }}
                    href={loginPath}>Login</Link>
            </nav>
        </Fragment>);
    }
}