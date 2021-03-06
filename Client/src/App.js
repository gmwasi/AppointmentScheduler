import { STATE_LOGIN, STATE_SIGNUP } from 'components/AuthForm';
import GAListener from 'components/GAListener';
import { EmptyLayout, LayoutRoute, MainLayout } from 'components/Layout';
import PageSpinner from 'components/PageSpinner';
import AuthPage from 'pages/AuthPage';
import React from 'react';
import componentQueries from 'react-component-queries';
import { BrowserRouter, Redirect, Switch } from 'react-router-dom';
import { Provider } from "react-redux";
import store from "./store";
import './styles/reduction.scss';
import { PrivateRoute } from "./PrivateRoute"

const DashboardPage = React.lazy(() => import('pages/DashboardPage'));
const UsersPage = React.lazy(() => import('pages/UsersPage'));
const AddUserPage = React.lazy(() => import('pages/AddUserPage'));
const RegisterPage = React.lazy(() => import('pages/RegisterPage'));
const AppointmentsPage = React.lazy(() => import('pages/AppointmentsPage'));
const SearchPage = React.lazy(() => import('pages/SearchPage'));
const ProfilePage = React.lazy(() => import('pages/ChildProfilePage'));
const AppointmentPage = React.lazy(() => import('pages/AppointmentCheckinPage'));
const PortalPage = React.lazy(() => import('pages/PortalPage'));
const AppointmentEditPage = React.lazy(() => import('pages/AppointmentEditPage'));

const getBasename = () => {
  return `/${process.env.PUBLIC_URL.split('/').pop()}`;
};

class App extends React.Component {
  render() {
    return (
      <Provider store={store}>
        <BrowserRouter basename={getBasename()}>
          <GAListener>
            <Switch>
              <LayoutRoute
                exact
                path="/login"
                layout={EmptyLayout}
                component={props => (
                  <AuthPage {...props} authState={STATE_LOGIN} />
                )}
              />
              <LayoutRoute
                exact
                path="/signup"
                layout={EmptyLayout}
                component={props => (
                  <AuthPage {...props} authState={STATE_SIGNUP} />
                )}
              />

              <MainLayout breakpoint={this.props.breakpoint}>
                <React.Suspense fallback={<PageSpinner />}>
                  <PrivateRoute exact path="/" component={DashboardPage} />
                  <PrivateRoute exact path="/users" roles={['Administrator']} component={UsersPage} />
                  <PrivateRoute exact path="/add-user" roles={['Administrator']} component={AddUserPage} />
                  <PrivateRoute exact path="/register" roles={['Administrator', 'User']} component={RegisterPage} />
                  <PrivateRoute exact path="/appointments" roles={['Administrator', 'User']} component={AppointmentsPage} />
                  <PrivateRoute exact path="/search" roles={['Administrator', 'User']} component={SearchPage} />
                  <PrivateRoute exact path="/profile/:id" roles={['Administrator', 'User']} component={ProfilePage} />
                  <PrivateRoute exact path="/profile/:childId/appointment/:id" roles={['Administrator', 'User']} component={AppointmentPage} />
                  <PrivateRoute exact path="/portal" roles={['CareGiver']} component={PortalPage} />
                  <PrivateRoute exact path="/edit-appointment/:id" roles={['CareGiver']} component={AppointmentEditPage} />
                </React.Suspense>
              </MainLayout>
              <Redirect to="/" />
            </Switch>
          </GAListener>
        </BrowserRouter>
      </Provider>
    );
  }
}

const query = ({ width }) => {
  if (width < 575) {
    return { breakpoint: 'xs' };
  }

  if (576 < width && width < 767) {
    return { breakpoint: 'sm' };
  }

  if (768 < width && width < 991) {
    return { breakpoint: 'md' };
  }

  if (992 < width && width < 1199) {
    return { breakpoint: 'lg' };
  }

  if (width > 1200) {
    return { breakpoint: 'xl' };
  }

  return { breakpoint: 'xs' };
};

export default componentQueries(query)(App);
