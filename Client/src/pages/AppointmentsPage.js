import axios from "axios";
import { url } from "../api";
import { connect } from 'react-redux';
import React, { useEffect, useState } from 'react';
import {
  Button,
  Card,
  CardBody,
  CardHeader,
  Col,
  Form,
  FormGroup,
  Input,
  Label,
  Row,
} from 'reactstrap';
import Page from 'components/Page';
import { getAppointmentSchedule } from '../actions/appointments';
import useForm from "../functions/UseForm";
import moment from 'moment';

const AppointmentsPage = props => {

  const { values, handleInputChange, resetForm } = useForm(
    {}
  );

  const [loading, setLoading] = useState(true);
  const [appointmentSchedule, setAppointmentSchedule] = useState([]);

  useEffect(() => {
    let dateOfBirth = moment(new Date()).format('YYYY-MM-DD');
    if (props.child.person && props.child.person.dateOfBirth) {
      dateOfBirth = props.child.person.dateOfBirth;
    }
    axios
      .get(`${url}appointments/schedule/${dateOfBirth}`)
      .then((response) => {
        setAppointmentSchedule(response.data);
        setLoading(false);
      })
      .catch((error) => {
        console.log(error)
      });
      props.fetchAppointments(dateOfBirth);
  }, []);

  const handleSubmit = event => {
    console.log(values);
    event.preventDefault();
  };

  return (
    <Page
      className="DashboardPage"
      title="Schedule Appointments"
      breadcrumbs={[{ name: 'Appointments', active: true }]}
    >
      <Form onSubmit={handleSubmit}>
        <Row>
          <Col lg="12" md="12" sm="12" xs="12">
            <Card>
              <CardHeader>Appointments Schedule</CardHeader>
              <CardBody>
                {!loading && (
                  <FormGroup>
                    {appointmentSchedule.map(({ appointmentDate, immunizationId, immunizationName }) => (
                      <Row>
                        <Col md={4}>
                          <Label for={`appointment-${immunizationId}`}>{immunizationName}</Label>
                        </Col>
                        <Col md={4}>
                          <Input
                            type="date"
                            name={`appointment-${immunizationId}`}
                            value={moment(appointmentDate).format('YYYY-MM-DD')}
                            onChange={handleInputChange}
                          />
                        </Col>
                        <Col md={4}>

                        </Col>
                      </Row>
                    ))}
                  </FormGroup>
                )}
              </CardBody>
            </Card>
          </Col>
        </Row>
        <Row>
          <Col xl={12} lg={12} md={12}>
            <Row form>
              <Col md={6}>
                <FormGroup check row>
                  <Col lg={{ size: 30, offset: 2 }}>
                    <Button onClick={resetForm}>Cancel</Button>
                  </Col>
                </FormGroup>
              </Col>
              <Col md={6}>
                <FormGroup check row>
                  <Col lg={{ size: 30, offset: 2 }}>
                    <Button>Submit</Button>
                  </Col>
                </FormGroup>
              </Col>
            </Row>
          </Col>
        </Row>
      </Form>
    </Page >

  );
};

const mapStateToProps = state => {
  return {
    appointments: state.appointments.schedule,
    child: state.children.child,
  };
};

const mapActionToProps = {
  fetchAppointments: getAppointmentSchedule,
};

export default connect(mapStateToProps, mapActionToProps)(AppointmentsPage);
