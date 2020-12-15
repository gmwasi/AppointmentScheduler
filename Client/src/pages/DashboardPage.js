import { connect } from "react-redux";
import React, { useEffect } from "react";
import Page from 'components/Page';
import {
  Card,
  CardBody,
  CardHeader,
  Col,
  Row,
} from 'reactstrap';
import FullCalendar from "@fullcalendar/react";
import dayGridPlugin from "@fullcalendar/daygrid";
import listPlugin from "@fullcalendar/list";
import { fetchAllAppointments } from "../actions/appointments";

const DashboardPage = (props) => {

  useEffect(() => {
    props.fetchAppointments();
  }, []);

  return (
    <Page
      className="DashboardPage"
      title="Dashboard"
      breadcrumbs={[{ name: 'Dashboard', active: true }]}
    >
      <Row>
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
      </Row>
    </Page>
  );
}

const mapStateToProps = (state) => {
  return {
    appointments: state.appointments.list,
  };
};

const mapActionToProps = {
  fetchAppointments: fetchAllAppointments,
};

export default connect(mapStateToProps, mapActionToProps)(DashboardPage);
