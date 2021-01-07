import { connect } from "react-redux";
import React, { useEffect } from "react";
import Page from 'components/Page';
import {
  Button,
  Card,
  CardBody,
  CardHeader,
  Col,
  Label,
  Form,
  FormGroup,
  Input,
  Row,
} from 'reactstrap';
import * as ACTION_TYPES from "../actions/types";
import { lookup } from "../actions/lookups";
import { fetchAppointmentById, updateAppointmentStatus } from "../actions/appointments";
import useForm from "../functions/UseForm";
import { toast } from "react-toastify";

const AppointmentEdit = {
  appointmentDate: '',
  reason: '',
};

const AppointmentEditPage = (props) => {

  const { values, handleInputChange } = useForm(
    AppointmentEdit
  );

  useEffect(() => {
    props.lookup("gender", ACTION_TYPES.LOOKUP_GENDER);
    props.lookup("appointmentStatusMark", ACTION_TYPES.LOOKUP_APPOINTMENT_STATUS);
    setTimeout(console.log(), 1500);
  }, []);

  useEffect(() => {
    const { match: { params } } = props;
    props.getAppointment(params.id);
  }, []);

  const handleSubmit = event => {
    event.preventDefault();
    const onSuccess = () => {
      toast.success("Appointment Successfully updated");
    };
    const onError = () => {
      toast.error("Something went wrong");
    };
    const { match: { params } } = props;
    console.log(values);
    props.updateAppointmentStatus(params.id, values.appointmentStatus, onSuccess, onError);
  };

  return (
    <Page
      className="DashboardPage"
      title="Edit Appointment"
      breadcrumbs={[{ name: 'Edit Appointment', active: true }]}
    >
      <Row>
        <Col xl={12} lg={12} md={12}>
          <Card>
            <CardHeader>Immunization Details</CardHeader>
            <CardBody>
              <Row>
                <Col md={12}>
                  <Label>Name</Label>
                  <Label><b>{props.appointment.immunization ? `: ${props.appointment.immunization.name}` : ''}</b></Label>
                </Col>
                <Col md={12}>
                  <Label>Description</Label>
                  <Label><b>{props.appointment.immunization ? `: ${props.appointment.immunization.description}` : ''}</b></Label>
                </Col>
                <Col md={12}>
                  <Label>Dose</Label>
                  <Label><b>{props.appointment.immunization ? `: ${props.appointment.immunization.dose}` : ''}</b></Label>
                </Col>
                <Col md={12}>
                  <Label>Mode of Administration</Label>
                  <Label><b>{props.appointment.immunization ? `: ${props.appointment.immunization.administrationMode}` : ''}</b></Label>
                </Col>
                <Col md={12}>
                  <Label>Side Effects</Label>
                  <Label><b>{props.appointment.immunization ? `: ${props.appointment.immunization.sideEffects}` : ''}</b></Label>
                </Col>
                <Col md={6}>
                  <Form onSubmit={handleSubmit}>
                    <FormGroup>
                      <Label for="appointmentDate">AppointmentDate</Label>
                      <Input
                        type="date"
                        name="appointmentDate"
                        id="appointmentDate"
                        placeholder="Appointment Date"
                        value={values.appointmentDate}
                        onChange={handleInputChange}
                      />
                    </FormGroup>
                    <FormGroup>
                      <Label for="reason">Reason</Label>
                      <Input
                        type="text"
                        name="reason"
                        placeholder="Reason"
                        value={values.reason}
                        onChange={handleInputChange}
                      />
                    </FormGroup>
                    <FormGroup check row>
                      <Button>Save</Button>
                    </FormGroup>
                  </Form>
                </Col>
              </Row>
            </CardBody>
          </Card>
        </Col>
      </Row>
    </Page>
  );
}

const mapStateToProps = (state) => {
  return {
    gender: state.lookups.genders,
    appointment: state.appointments.appointment,
    appointmentStatus: state.lookups.appointmentStatuses,
  };
};

const mapActionToProps = {
  lookup: lookup,
  getAppointment: fetchAppointmentById,
  updateAppointmentStatus: updateAppointmentStatus,
};

export default connect(mapStateToProps, mapActionToProps)(AppointmentEditPage);
