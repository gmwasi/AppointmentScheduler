import { connect } from "react-redux";
import React, { useEffect } from "react";
import Page from 'components/Page';
import {
  Card,
  CardBody,
  CardHeader,
  Col,
  Label,
  Row,
  NavLink as BSNavLink,
} from 'reactstrap';
import { NavLink } from 'react-router-dom';
import FullCalendar from "@fullcalendar/react";
import dayGridPlugin from "@fullcalendar/daygrid";
import listPlugin from "@fullcalendar/list";
import * as ACTION_TYPES from "../actions/types";
import { lookup } from "../actions/lookups";
import { fetchAllAppointments } from "../actions/appointments";
import { getByEmail } from "../actions/children";
import { authentication } from '../_services/authentication';
import MaterialTable from 'material-table'
import moment from 'moment';

const DashboardPage = (props) => {

  useEffect(() => {
    props.lookup("gender", ACTION_TYPES.LOOKUP_GENDER);
    props.lookup("maritalStatus", ACTION_TYPES.LOOKUP_MARITAL_STATUS);
    props.lookup("appointmentStatus", ACTION_TYPES.LOOKUP_APPOINTMENT_STATUS);
  }, []);


  useEffect(() => {
    props.fetchAppointments();
  }, []);

  useEffect(() => {
    if (authentication.currentRole === 'CareGiver') {
      props.getChild(authentication.currentUsername);
    }
  }, []);

  return (
    <Page
      className="DashboardPage"
      title="Dashboard"
      breadcrumbs={[{ name: 'Dashboard', active: true }]}
    >
      {(authentication.currentRole === 'Administrator' || authentication.currentRole === 'User') && (<Row>
        <Col lg="12" md="12" sm="12" xs="12">
          <Card>
            <CardHeader>
              Appointment Calendar{' '}
            </CardHeader>
            <CardBody>
              <FullCalendar
                plugins={[dayGridPlugin, listPlugin]}
                initialView="dayGridWeek"
                headerToolbar={{
                  left: "prev,next",
                  center: "title",
                  right: "dayGridDay,dayGridWeek,dayGridMonth,listDay",
                }}
                weekends={true}
                events={props.appointments.map((row) => ({
                  id: row.id,
                  title:
                    row.child.uniqueNumber +
                    " - " +
                    row.child.person.firstName +
                    " " +
                    row.child.person.lastName + " - "
                    + row.immunization.description,
                  date: row.appointmentDate,
                  extendedProps: row,
                }))}
              />
            </CardBody>
          </Card>
        </Col>
      </Row>)}
      {(authentication.currentRole === 'CareGiver') && (<Row>
        <Col xl={6} lg={6} md={6}>
          <Card>
            <CardHeader>Child Details</CardHeader>
            <CardBody>
              <Row>
                <Col md={6}>
                  <Label>First Name</Label>
                  <Label><b>{props.child.person ? `: ${props.child.person.firstName}` : ''}</b></Label>
                </Col>
                <Col md={6}>
                  <Label>Middle Name</Label>
                  <Label><b>{props.child.person ? `: ${props.child.person.middleName}` : ''}</b></Label>
                </Col>
                <Col md={6}>
                  <Label>Last Name</Label>
                  <Label><b>{props.child.person ? `: ${props.child.person.lastName}` : ''}</b></Label>
                </Col>
                <Col md={6}>
                  <Label>Gender</Label>
                  <Label><b>{props.child.person ? `: ${props.gender.find(o => o.id === props.child.person.genderId).name}` : ''}</b></Label>
                </Col>
                <Col md={6}>
                  <Label>Unique Number</Label>
                  <Label><b>{props.child.person ? `: ${props.child.uniqueNumber}` : ''}</b></Label>
                </Col>
                <Col md={6}>
                  <Label>Date of Birth</Label>
                  <Label><b>{props.child.person ? `: ${moment(props.child.person.dateOfBirth).format('YYYY-MM-DD')}` : ''}</b></Label>
                </Col>
              </Row>
            </CardBody>
          </Card>
        </Col>
        <Col xl={6} lg={6} md={6}>
          <Card>
            <CardHeader>Care Giver Details</CardHeader>
            <CardBody>
              <Row>
                <Col md={6}>
                  <Label>First Name</Label>
                  <Label><b>{props.child.careGiver ? `: ${props.child.careGiver.firstName}` : ''}</b></Label>
                </Col>
                <Col md={6}>
                  <Label>Middle Name</Label>
                  <Label><b>{props.child.careGiver ? `: ${props.child.careGiver.middleName}` : ''}</b></Label>
                </Col>
                <Col md={6}>
                  <Label>Last Name</Label>
                  <Label><b>{props.child.careGiver ? `: ${props.child.careGiver.lastName}` : ''}</b></Label>
                </Col>
                <Col md={6}>
                  <Label>Gender</Label>
                  <Label><b>{props.child.careGiver ? `: ${props.gender.find(o => o.id === props.child.careGiver.genderId).name}` : ''}</b></Label>
                </Col>
                <Col md={6}>
                  <Label>Marital Status</Label>
                  <Label><b>{props.child.careGiver ? `: ${props.maritalStatus.find(o => o.id === props.child.careGiver.maritalStatusId).name}` : ''}</b></Label>
                </Col>
                <Col md={6}>
                  <Label>Date of Birth</Label>
                  <Label><b>{props.child.careGiver ? `: ${moment(props.child.careGiver.dateOfBirth).format('YYYY-MM-DD')}` : ''}</b></Label>
                </Col>
              </Row>
            </CardBody>
          </Card>
        </Col>
      </Row>)}
      {(authentication.currentRole === 'CareGiver') && (<Row>
        <Col lg="12" md="12" sm="12" xs="12">
          <MaterialTable
            options={{
              paging: false
            }}
            columns={[
              { title: 'Immunization Name', field: 'immunization' },
              { title: 'Appointment Date', field: 'date' },
              { title: 'Appointment Status', field: 'status' },
              { title: 'Actions', field: 'actions' }
            ]}
            data={props.childppointments.map((row) => ({
              immunization: row.immunization.name,
              date: moment(row.appointmentDate).format('YYYY-MMM-DD'),
              status: props.appointmentStatus.find(o => o.id === row.appointmentStatus).name,
              actions: (
                <BSNavLink
                  id={`appointment${row.id}`}
                  tag={NavLink}
                  to={`/edit-appointment/${row.id}`}
                  activeClassName="active"
                  exact={true}
                >
                  <span style={{ color: "#000" }}>Request Reschedule</span>
                </BSNavLink>
              ),
            }))}
            title="Appointments"
          />
        </Col>
      </Row>)}
    </Page>
  );
}

const mapStateToProps = (state) => {
  return {
    appointments: state.appointments.list,
    gender: state.lookups.genders,
    maritalStatus: state.lookups.maritalStatuses,
    child: state.children.child,
    appointmentStatus: state.lookups.appointmentStatuses,
    childppointments: state.appointments.child,
  };
};

const mapActionToProps = {
  lookup: lookup,
  fetchAppointments: fetchAllAppointments,
  getChild: getByEmail,
};

export default connect(mapStateToProps, mapActionToProps)(DashboardPage);
