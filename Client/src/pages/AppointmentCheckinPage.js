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
import { getById } from "../actions/children";
import { fetchAppointmentById, updateAppointmentStatus } from "../actions/appointments";
import useForm from "../functions/UseForm";
import moment from 'moment';
import { toast } from "react-toastify";

const CheckinPageForm = {
    appointmentStatus: 'Scheduled',
};

const AppointmentCheckinPage = (props) => {

    const { values, handleInputChange } = useForm(
        CheckinPageForm
    );

    useEffect(() => {
        props.lookup("gender", ACTION_TYPES.LOOKUP_GENDER);
        props.lookup("appointmentStatusMark", ACTION_TYPES.LOOKUP_APPOINTMENT_STATUS);
        setTimeout(console.log(), 1500); 
    }, []);

    useEffect(() => {
        const { match: { params } } = props;
        props.getChild(params.childId);
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
            title="Appointment Checkin"
            breadcrumbs={[{ name: 'Appointment Checkin', active: true }]}
        >
            <Row>
                <Col xl={12} lg={12} md={12}>
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
            </Row>
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
                                            <Label for="appointmentStatus">Appointment Status</Label>
                                            <Input
                                                type="select"
                                                name="appointmentStatus"
                                                id="appointmentStatus"
                                                placeholder="Select Appointment Status"
                                                value={values.appointmentStatus}
                                                onChange={handleInputChange}
                                            >
                                                <option value=""> </option>
                                                {props.appointmentStatus.map(({ name, id }) => (
                                                    <option key={id} value={id}>
                                                        {name}
                                                    </option>
                                                ))}
                                            </Input>
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
        child: state.children.child,
        appointment: state.appointments.appointment,
        appointmentStatus: state.lookups.appointmentStatuses,
    };
};

const mapActionToProps = {
    lookup: lookup,
    getChild: getById,
    getAppointment: fetchAppointmentById,
    updateAppointmentStatus: updateAppointmentStatus,
};

export default connect(mapStateToProps, mapActionToProps)(AppointmentCheckinPage);
