import { connect } from "react-redux";
import React, { useEffect } from "react";
import Page from 'components/Page';
import {
  Button,
  Card,
  CardBody,
  Col,
  Row,
  NavLink as BSNavLink,
} from 'reactstrap';
import { NavLink, Link } from 'react-router-dom';
import { MdAccountCircle } from "react-icons/md";
import { fetchAll } from "../actions/users";
import MaterialTable from 'material-table'

const UsersPage = (props) => {

  useEffect(() => {
    props.fetchUsers();
  }, []);

  return (
    <Page
      className="DashboardPage"
      title="Users"
      breadcrumbs={[{ name: 'Users', active: true }]}
    >
      <Row>
        <Col xl={12} lg={12} md={12}>
          <Card>
            <CardBody>
              <Link to="/add-user">
                <Button
                  variant="contained"
                  color="primary"
                  className=" float-right mr-1"
                >
                  <span style={{ textTransform: "capitalize" }}>Add User</span>
                </Button>
              </Link>
            </CardBody>
          </Card>
        </Col>
      </Row>
      <Row>
        <Col lg="12" md="12" sm="12" xs="12">
          <MaterialTable
            columns={[
              { title: 'User Name', field: 'username' },
              { title: 'Email', field: 'email' },
              { title: 'Actions', field: 'actions' }
            ]}
            data={props.users.map((row) => ({
              username: row.userName,
              email: row.email,
              actions: (
                <BSNavLink
                  id={`profile${row.id}`}
                  tag={NavLink}
                  to={`/profile/${row.id}`}
                  activeClassName="active"
                  exact={true}
                >
                  <MdAccountCircle size="15" />{" "}
                  <span style={{ color: "#000" }}>View Profile</span>
                </BSNavLink>
              ),
            }))}
            title="Users"
          />
        </Col>
      </Row>
    </Page>
  );
}

const mapStateToProps = (state) => {
  return {
    users: state.users.list,
  };
};

const mapActionToProps = {
  fetchUsers: fetchAll,
};

export default connect(mapStateToProps, mapActionToProps)(UsersPage);