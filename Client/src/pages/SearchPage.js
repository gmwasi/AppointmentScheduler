import { connect } from "react-redux";
import React, { useEffect } from "react";
import Page from 'components/Page';
import {
  Button,
  Col,
  Row,
} from 'reactstrap';
import { MdAccountCircle } from "react-icons/md";
import * as ACTION_TYPES from "../actions/types";
import { lookup } from "../actions/lookups";
import { fetchAll, find } from "../actions/children";
import MaterialTable from 'material-table'
import moment from 'moment';

const SearchPage = (props) => {

  useEffect(() => {
    props.fetchGenders("gender", ACTION_TYPES.LOOKUP_GENDER);
  }, []);

  useEffect(() => {
    props.fetchChildren();
  }, []);

  return (
    <Page
      className="DashboardPage"
      title="Search"
      breadcrumbs={[{ name: 'Search Child', active: true }]}
    >
      <Row>
        <Col lg="12" md="12" sm="12" xs="12">
          <MaterialTable
            columns={[
              { title: 'Unique Number', field: 'uniqueNumber' },
              { title: 'Name', field: 'name' },
              { title: 'Gender', field: 'gender' },
              { title: 'Date of Birth', field: 'dateOfBirth' },
              { title: 'Care Giver', field: 'careGiver' },
              { title: 'Actions', field: 'actions' }
            ]}
            data={props.children.map((row) => ({
              uniqueNumber: row.uniqueNumber,
              name: row.person.firstName + " " + row.person.middleName + " " + row.person.lastName,
              gender: props.gender.find(o => o.id === row.person.genderId).name,
              dateOfBirth: moment(row.person.dateOfBirth).format('YYYY-MM-DD'),
              careGiver: row.careGiver.firstName + " " + row.careGiver.middleName + " " + row.careGiver.lastName,
              actions: (
                <Button
                  size="sm"
                  color="link"
                  onClick={() => console.log('click')}
                >
                  <MdAccountCircle size="15" />{" "}
                  <span style={{ color: "#000" }}>View Profile</span>
                </Button>
              ),
            }))}
            title="Children"
          />
        </Col>
      </Row>
    </Page>
  );
}

const mapStateToProps = (state) => {
  return {
    gender: state.lookups.genders,
    children: state.children.list,
    searchResult: state.children.searchList,
  };
};

const mapActionToProps = {
  fetchGenders: lookup,
  fetchChildren: fetchAll,
  searchChildren: find,
};

export default connect(mapStateToProps, mapActionToProps)(SearchPage);
