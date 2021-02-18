import SourceLink from 'components/SourceLink';
import React from 'react';
import {
  MdDashboard,
  MdInfo,
  MdFace,
  MdKeyboardArrowDown,
  MdPersonAdd,
  MdRadioButtonChecked,
  MdSearch,
  MdWeb,
  MdSettings,
} from 'react-icons/md';
import { NavLink } from 'react-router-dom';
import {
  // UncontrolledTooltip,
  Collapse,
  Nav,
  Navbar,
  NavItem,
  NavLink as BSNavLink,
} from 'reactstrap';
import bn from 'utils/bemnames';
import { authentication } from '../../_services/authentication';

const navComponents = [
  { to: '/', name: 'Report 1', exact: false, Icon: MdRadioButtonChecked },
];
let navItems = [];
if (authentication.currentRole === 'Administrator' || authentication.currentRole === 'User') {
  navItems = [
    { to: '/', name: 'dashboard', exact: true, Icon: MdDashboard },
    { to: '/register', name: 'register', exact: true, Icon: MdPersonAdd },
    { to: '/search', name: 'Find Child', exact: false, Icon: MdSearch },
  ];
} else if (authentication.currentRole === 'CareGiver') {
  navItems = [
    { to: '/', name: 'dashboard', exact: true, Icon: MdDashboard },
    { to: '/portal', name: 'portal', exact: true, Icon: MdInfo },
  ];
}

const navAdmin = [
  { to: '/users', name: 'Users', exact: false, Icon: MdFace },
];

const bem = bn.create('sidebar');

class Sidebar extends React.Component {
  state = {
    isOpenReports: false,
    isOpenAdmie: false,
  };

  handleClick = name => () => {
    this.setState(prevState => {
      const isOpen = prevState[`isOpen${name}`];

      return {
        [`isOpen${name}`]: !isOpen,
      };
    });
  };

  render() {
    return (
      <aside className={bem.b()}>
        <div className={bem.e('content')}>
          <Navbar>
            <SourceLink className="navbar-brand d-flex">
              <span className="text-white">MCH Appointments</span>
            </SourceLink>
          </Navbar>
          <Nav vertical>
            {navItems.map(({ to, name, exact, Icon }, index) => (
              <NavItem key={index} className={bem.e('nav-item')}>
                <BSNavLink
                  id={`navItem-${name}-${index}`}
                  className="text-uppercase"
                  tag={NavLink}
                  to={to}
                  activeClassName="active"
                  exact={exact}
                >
                  <Icon className={bem.e('nav-item-icon')} />
                  <span className="">{name}</span>
                </BSNavLink>
              </NavItem>
            ))}

            {(authentication.currentRole === 'Administrator' || authentication.currentRole === 'User') && (<NavItem
              className={bem.e('nav-item')}
              onClick={this.handleClick('Reports')}
            >
              <BSNavLink className={bem.e('nav-item-collapse')}>
                <div className="d-flex">
                  <MdWeb className={bem.e('nav-item-icon')} />
                  <span className=" align-self-start">Reports</span>
                </div>
                <MdKeyboardArrowDown
                  className={bem.e('nav-item-icon')}
                  style={{
                    padding: 0,
                    transform: this.state.isOpenReports
                      ? 'rotate(0deg)'
                      : 'rotate(-90deg)',
                    transitionDuration: '0.3s',
                    transitionProperty: 'transform',
                  }}
                />
              </BSNavLink>
            </NavItem>)}
            <Collapse isOpen={this.state.isOpenReports}>
              {navComponents.map(({ to, name, exact, Icon }, index) => (
                <NavItem key={index} className={bem.e('nav-item')}>
                  <BSNavLink
                    id={`navItem-${name}-${index}`}
                    className="text-uppercase"
                    tag={NavLink}
                    to={to}
                    activeClassName="active"
                    exact={exact}
                  >
                    <Icon className={bem.e('nav-item-icon')} />
                    <span className="">{name}</span>
                  </BSNavLink>
                </NavItem>
              ))}
            </Collapse>

            {(authentication.currentRole === 'Administrator') && (<NavItem
              className={bem.e('nav-item')}
              onClick={this.handleClick('Admin')}
            >
              <BSNavLink className={bem.e('nav-item-collapse')}>
                <div className="d-flex">
                  <MdSettings className={bem.e('nav-item-icon')} />
                  <span className=" align-self-start">Admin</span>
                </div>
                <MdKeyboardArrowDown
                  className={bem.e('nav-item-icon')}
                  style={{
                    padding: 0,
                    transform: this.state.isOpenAdmin
                      ? 'rotate(0deg)'
                      : 'rotate(-90deg)',
                    transitionDuration: '0.3s',
                    transitionProperty: 'transform',
                  }}
                />
              </BSNavLink>
            </NavItem>)}
            <Collapse isOpen={this.state.isOpenAdmin}>
              {navAdmin.map(({ to, name, exact, Icon }, index) => (
                <NavItem key={index} className={bem.e('nav-item')}>
                  <BSNavLink
                    id={`navItem-${name}-${index}`}
                    className="text-uppercase"
                    tag={NavLink}
                    to={to}
                    activeClassName="active"
                    exact={exact}
                  >
                    <Icon className={bem.e('nav-item-icon')} />
                    <span className="">{name}</span>
                  </BSNavLink>
                </NavItem>
              ))}
            </Collapse>
          </Nav>
        </div>
      </aside>
    );
  }
}

export default Sidebar;
