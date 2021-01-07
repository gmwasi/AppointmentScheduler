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
import { getAppointmentSchedule, saveAppointments } from '../actions/appointments';
import moment from 'moment';
import { toast } from "react-toastify";

const AppointmentsPage = props => {

  const [loading, setLoading] = useState(true);
  const [appointmentSchedule, setAppointmentSchedule] = useState([]);



  useEffect(() => {
    let dateOfBirth = moment(new Date()).format('YYYY-MM-DD');
    if (props.child.person && props.child.person.dateOfBirth) {
      dateOfBirth = moment(props.child.person.dateOfBirth).format('YYYY-MM-DD');
    }
    axios
      .get(`${url}appointments/schedule/${dateOfBirth}`)
      .then((response) => {
        let result = response.data;
        result.forEach(element => {
          element.attended = false;
          const date = moment(element.appointmentDate).format('YYYY-MM-DD');
          element.appointmentDate = date;
        });
        setAppointmentSchedule(result);
        setLoading(false);
      })
      .catch((error) => {
        console.log(error)
      });
    props.fetchAppointments(dateOfBirth);
  }, []);

  const handleInputChange = e => {
    const { name, value } = e.target;
    let data = appointmentSchedule;
    data[name].appointmentDate = value;
    setAppointmentSchedule(data);
  };

  const handleCheckChange = e => {
    const { name, checked } = e.target;
    let data = appointmentSchedule;
    data[name].attended = checked;
    setAppointmentSchedule(data);
  };

  const handleSubmit = event => {
    event.preventDefault();
    const onSuccess = () => {
      toast.success("Saved Successfully");
      props.history.push("/");
    };
    const onError = () => {
      toast.error("Something went wrong");
    };
    let data = appointmentSchedule;
    data.forEach(element => {
      element.childId = props.child.id;
    });
    
    props.saveAppointments(data, onSuccess, onError);
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
                    {appointmentSchedule.map(({ appointmentDate, immunizationName }, index) => (
                      <Row key={`Row-${index}`} >
                        <Col md={4}>
                          <Label for={`appointment-${index}`}>{immunizationName}</Label>
                        </Col>
                        <Col md={4}>
                          <Input
                            type="date"
                            name={index}
                            defaultValue={moment(appointmentDate).format('YYYY-MM-DD')}
                            onChange={handleInputChange}
                          />
                        </Col>
                        <Col md={4}>
                          <FormGroup check>
                            <Label check>
                              <Input
                                name={index}
                                type="checkbox"
                                onChange={handleCheckChange}
                              /> Attended
                            </Label>
                          </FormGroup>
                        </Col>
                      </Row>
                    ))}
                  </FormGroup>
                )}
                <Row>
                  <Col xl={12} lg={12} md={12}>
                    <Row form>
                      <Col md={12}>
                        <FormGroup check row>
                          <Col lg={{ size: 30, offset: 2 }}>
                            <Button>Submit</Button>
                          </Col>
                        </FormGroup>
                      </Col>
                    </Row>
                  </Col>
                </Row>
              </CardBody>
            </Card>
          </Col>
        </Row>
      </Form>
    </Page >

  );
};

const mapStateToProps = state => {
  return {
    appointments: state.appointments.schedule,
    child: state.children.registered,
  };
};

const mapActionToProps = {
  saveAppointments: saveAppointments,
  fetchAppointments: getAppointmentSchedule,
};

export default connect(mapStateToProps, mapActionToProps)(AppointmentsPage);
