import Page from 'components/Page';
import { connect } from "react-redux";
import React, { useEffect } from "react";
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
import * as ACTION_TYPES from "../actions/types";
import { lookup } from "../actions/lookups";
import { register } from "../actions/children";
import useForm from "../functions/UseForm";
import { toast } from "react-toastify";

const childRegistration = {
  child_hudumaNamba: '',
  child_firstName: '',
  child_lastName: '',
  child_middleName: '',
  child_genderId: 0,
  child_maritalStatusId: 3,
  child_dateOfbirth: '',
  careGiver_hudumaNamba: '',
  careGiver_firstName: '',
  careGiver_lastName: '',
  careGiver_middleName: '',
  careGiver_genderId: 0,
  careGiver_maritalStatusId: 0,
  careGiver_dateOfbirth: '',
  uniqueNumber: '',
  email: '',
  phoneNumber: '',
  physicalAddress: '',
  postalAddress: '',
  countyId: 0,
  facilityId: 1,
  relative_name: '',
  relative_email: '',
  relative_phoneNumber: '',
  relative_physicalAddress: '',
  relative_postalAddress: '',
  relationshipId: 0,
}

const map = (values) => {
  const data = {
    child: {
      hudumaNamba: values.child_hudumaNamba,
      firstName: values.child_firstName,
      middleName: values.child_middleName,
      lastName: values.child_lastName,
      genderId: values.child_genderId,
      maritalStatusId: values.child_maritalStatusId,
      facilityId: values.facilityId,
      uniqueNumber: values.uniqueNumber,
      dateOfBirth: values.child_dateOfBirth
    },
    careGiver: {
      hudumaNamba: values.careGiver_hudumaNamba,
      firstName: values.careGiver_firstName,
      middleName: values.careGiver_middleName,
      lastName: values.careGiver_lastName,
      genderId: values.careGiver_genderId,
      maritalStatusId: values.careGiver_maritalStatusId,
      facilityId: values.facilityId,
      dateOfBirth: values.careGiver_dateOfBirth
    },
    contact: {
      phoneNumber: values.phoneNumber,
      email: values.email,
      postalAddress: values.postalAddress,
      physicalAddress: values.physicalAddress,
      countyId: values.countyId
    },
    relative: {
      name: values.relative_name,
      email: values.relative_email,
      phoneNumber: values.relative_phoneNumber,
      postalAddress: values.relative_postalAddress,
      physicalAddress: values.relative_physicalAddress,
      relationshipId: values.relationshipId
    }
  }
  return data;
}

const RegisterPage = (props) => {

  const { values, handleInputChange, resetForm } = useForm(
    childRegistration
  );

  useEffect(() => {
    props.fetchGenders("gender", ACTION_TYPES.LOOKUP_GENDER);
  }, []);

  useEffect(() => {
    props.fetchMaritalStatus(
      "maritalStatus",
      ACTION_TYPES.LOOKUP_MARITAL_STATUS,
    );
  }, []);

  useEffect(() => {
    props.fetchRelationships("relationship", ACTION_TYPES.LOOKUP_RELATIONSHIP);
  }, []);

  useEffect(() => {
    props.fetchCounty("county", ACTION_TYPES.LOOKUP_COUNTY);
  }, []);

  const handleSubmit = event => {
    event.preventDefault();
    const data = map(values);
    const onSuccess = () => {
      toast.success("Registration Successful");
      resetForm();
      props.history.push("/appointments");
    };
    const onError = () => {
      toast.error("Something went wrong");
    };
    props.register(data, onSuccess, onError);

  };

  return (
    <Page title="Register Child" breadcrumbs={[{ name: 'Register', active: true }]}>
      <Form onSubmit={handleSubmit}>
        <Row>
          <Col xl={12} lg={12} md={12}>
            <Card>
              <CardHeader>Child Details</CardHeader>
              <CardBody>
                <Row form>
                  <Col md={6}>
                    <FormGroup>
                      <Label for="child_firstName">First Name</Label>
                      <Input
                        type="text"
                        name="child_firstName"
                        placeholder="First Name"
                        value={values.child_firstName}
                        onChange={handleInputChange}
                      />
                    </FormGroup>
                  </Col>
                  <Col md={6}>
                    <FormGroup>
                      <Label for="child_middleName">Middle Name</Label>
                      <Input
                        type="text"
                        name="child_middleName"
                        placeholder="Middle Name"
                        value={values.child_middleName}
                        onChange={handleInputChange}
                      />
                    </FormGroup>
                  </Col>
                  <Col md={6}>
                    <FormGroup>
                      <Label for="child_lastName">Last Name</Label>
                      <Input
                        type="text"
                        name="child_lastName"
                        placeholder="Last Name"
                        value={values.child_lastName}
                        onChange={handleInputChange}
                      />
                    </FormGroup>
                  </Col>
                  <Col md={6}>
                    <FormGroup>
                      <Label for="child_hudumaNamba">Huduma Namba</Label>
                      <Input
                        type="text"
                        name="child_hudumaNamba"
                        placeholder="Huduma Namba"
                        value={values.child_hudumaNamba}
                        onChange={handleInputChange}
                      />
                    </FormGroup>
                  </Col>
                  <Col md={6}>
                    <FormGroup>
                      <Label for="uniqueNumber">Unique Number</Label>
                      <Input
                        type="text"
                        name="uniqueNumber"
                        placeholder="Unique Number"
                        value={values.uniqueNumber}
                        onChange={handleInputChange}
                      />
                    </FormGroup>
                  </Col>
                  <Col md={6}>
                    <FormGroup>
                      <Label for="child_dateOfBirth">Date of Birth</Label>
                      <Input
                        type="date"
                        name="child_dateOfBirth"
                        id="child_dateOfBirth"
                        placeholder="Date of Birth"
                        value={values.child_dateOfBirth}
                        onChange={handleInputChange}
                      />
                    </FormGroup>
                  </Col>
                  <Col md={6}>
                    <FormGroup>
                      <Label for="child_genderId">Gender</Label>
                      <Input
                        type="select"
                        name="child_genderId"
                        id="child_genderId"
                        placeholder="Select Gender"
                        value={values.child_genderId}
                        onChange={handleInputChange}
                      >
                        <option value=""> </option>
                        {props.gender.map(({ name, id }) => (
                          <option key={id} value={id}>
                            {name}
                          </option>
                        ))}
                      </Input>
                    </FormGroup>
                  </Col>
                </Row>
              </CardBody>
            </Card>
          </Col>

          <Col xl={12} lg={12} md={12}>
            <Card>
              <CardHeader>Care Giver Details</CardHeader>
              <CardBody>
                <Row form>
                  <Col md={6}>
                    <FormGroup>
                      <Label for="careGiver_firstName">First Name</Label>
                      <Input
                        type="text"
                        name="careGiver_firstName"
                        placeholder="First Name"
                        value={values.careGiver_firstName}
                        onChange={handleInputChange}
                      />
                    </FormGroup>
                  </Col>
                  <Col md={6}>
                    <FormGroup>
                      <Label for="careGiver_middleName">Middle Name</Label>
                      <Input
                        type="text"
                        name="careGiver_middleName"
                        placeholder="Middle Name"
                        value={values.careGiver_middleName}
                        onChange={handleInputChange}
                      />
                    </FormGroup>
                  </Col>
                  <Col md={6}>
                    <FormGroup>
                      <Label for="careGiver_lastName">Last Name</Label>
                      <Input
                        type="text"
                        name="careGiver_lastName"
                        placeholder="Last Name"
                        value={values.careGiver_lastName}
                        onChange={handleInputChange}
                      />
                    </FormGroup>
                  </Col>
                  <Col md={6}>
                    <FormGroup>
                      <Label for="careGiver_hudumaNamba">Huduma Namba</Label>
                      <Input
                        type="text"
                        name="careGiver_hudumaNamba"
                        placeholder="Huduma Namba"
                        value={values.careGiver_hudumaNamba}
                        onChange={handleInputChange}
                      />
                    </FormGroup>
                  </Col>
                  <Col md={6}>
                    <FormGroup>
                      <Label for="careGiver_dateOfBirth">Date of Birth</Label>
                      <Input
                        type="date"
                        name="careGiver_dateOfBirth"
                        id="careGiver_dateOfBirth"
                        placeholder="Date of Birth"
                        value={values.careGiver_dateOfBirth}
                        onChange={handleInputChange}
                      />
                    </FormGroup>
                  </Col>
                  <Col md={6}>
                    <FormGroup>
                      <Label for="careGiver_genderId">Gender</Label>
                      <Input
                        type="select"
                        name="careGiver_genderId"
                        id="careGiver_genderId"
                        placeholder="Select Gender"
                        value={values.careGiver_genderId}
                        onChange={handleInputChange}
                      >
                        <option value=""> </option>
                        {props.gender.map(({ name, id }) => (
                          <option key={id} value={id}>
                            {name}
                          </option>
                        ))}
                      </Input>
                    </FormGroup>
                  </Col>
                  <Col md={6}>
                    <FormGroup>
                      <Label for="careGiver_maritalStatusId">Marital Status</Label>
                      <Input
                        type="select"
                        name="careGiver_maritalStatusId"
                        id="careGiver_maritalStatusId"
                        placeholder="Select Marital Status"
                        value={values.careGiver_maritalStatusId}
                        onChange={handleInputChange}
                      >
                        <option value=""> </option>
                        {props.maritalStatus.map(({ name, id }) => (
                          <option key={id} value={id}>
                            {name}
                          </option>
                        ))}
                      </Input>
                    </FormGroup>
                  </Col>
                </Row>
              </CardBody>
            </Card>
          </Col>
        </Row>

        <Row>
          <Col xl={12} lg={12} md={12}>
            <Card>
              <CardHeader>Contact Details</CardHeader>
              <CardBody>
                <Row form>
                  <Col md={6}>
                    <FormGroup>
                      <Label for="phoneNumber">Phone Number</Label>
                      <Input
                        type="text"
                        name="phoneNumber"
                        placeholder="Phone Number"
                        value={values.phoneNumber}
                        onChange={handleInputChange}
                      />
                    </FormGroup>
                  </Col>
                  <Col md={6}>
                    <FormGroup>
                      <Label for="email">Email</Label>
                      <Input
                        type="email"
                        name="email"
                        placeholder="Email"
                        value={values.email}
                        onChange={handleInputChange}
                      />
                    </FormGroup>
                  </Col>
                  <Col md={6}>
                    <FormGroup>
                      <Label for="postalAddress">Postal Address</Label>
                      <Input
                        type="text"
                        name="postalAddress"
                        placeholder="Postal Address"
                        value={values.postalAddress}
                        onChange={handleInputChange}
                      />
                    </FormGroup>
                  </Col>
                  <Col md={6}>
                    <FormGroup>
                      <Label for="physicalAddress">Physical Address</Label>
                      <Input
                        type="text"
                        name="physicalAddress"
                        placeholder="Physical Address"
                        value={values.physicalAddress}
                        onChange={handleInputChange}
                      />
                    </FormGroup>
                  </Col>
                  <Col md={6}>
                    <FormGroup>
                      <Label for="countyId">County</Label>
                      <Input
                        type="select"
                        name="countyId"
                        id="countyId"
                        placeholder="Select County"
                        value={values.countyId}
                        onChange={handleInputChange}
                      >
                        <option value=""> </option>
                        {props.counties.map(({ name, id }) => (
                          <option key={id} value={id}>
                            {name}
                          </option>
                        ))}
                      </Input>
                    </FormGroup>
                  </Col>
                </Row>
              </CardBody>
            </Card>
          </Col>

          <Col xl={12} lg={12} md={12}>
            <Card>
              <CardHeader>Contact Relative</CardHeader>
              <CardBody>
                <Row form>
                  <Col md={6}>
                    <FormGroup>
                      <Label for="relative_name">Name</Label>
                      <Input
                        type="text"
                        name="relative_name"
                        placeholder="Name"
                        value={values.relative_name}
                        onChange={handleInputChange}
                      />
                    </FormGroup>
                  </Col>
                  <Col md={6}>
                    <FormGroup>
                      <Label for="relative_phoneNumber">Phone Number</Label>
                      <Input
                        type="text"
                        name="relative_phoneNumber"
                        placeholder="Phone Number"
                        value={values.relative_phoneNumber}
                        onChange={handleInputChange}
                      />
                    </FormGroup>
                  </Col>
                  <Col md={6}>
                    <FormGroup>
                      <Label for="relative_email">Email</Label>
                      <Input
                        type="email"
                        name="relative_email"
                        placeholder="Email"
                        value={values.relative_email}
                        onChange={handleInputChange}
                      />
                    </FormGroup>
                  </Col>
                  <Col md={6}>
                    <FormGroup>
                      <Label for="relative_postalAddress">Postal Address</Label>
                      <Input
                        type="text"
                        name="relative_postalAddress"
                        placeholder="Postal Address"
                        value={values.relative_postalAddress}
                        onChange={handleInputChange}
                      />
                    </FormGroup>
                  </Col>
                  <Col md={6}>
                    <FormGroup>
                      <Label for="relative_physicalAddress">Physical Address</Label>
                      <Input
                        type="text"
                        name="relative_physicalAddress"
                        placeholder="Physical Address"
                        value={values.relative_physicalAddress}
                        onChange={handleInputChange}
                      />
                    </FormGroup>
                  </Col>
                  <Col md={6}>
                    <FormGroup>
                      <Label for="countyId">Relationship</Label>
                      <Input
                        type="select"
                        name="relationshipId"
                        id="relationshipId"
                        placeholder="Select Relationship"
                        value={values.relationshipId}
                        onChange={handleInputChange}
                      >
                        <option value=""> </option>
                        {props.relationships.map(({ name, id }) => (
                          <option key={id} value={id}>
                            {name}
                          </option>
                        ))}
                      </Input>
                    </FormGroup>
                  </Col>
                </Row>
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
    </Page>
  );
};

const mapStateToProps = (state) => {
  return {
    registred: state.children.registred,
    gender: state.lookups.genders,
    maritalStatus: state.lookups.maritalStatuses,
    relationships: state.lookups.relationships,
    counties: state.lookups.counties,
  };
};

const mapActionToProps = {
  register: register,
  fetchGenders: lookup,
  fetchMaritalStatus: lookup,
  fetchRelationships: lookup,
  fetchCounty: lookup,
};

export default connect(mapStateToProps, mapActionToProps)(RegisterPage);
