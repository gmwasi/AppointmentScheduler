import { connect } from "react-redux";
import React, {  } from "react";
import Page from 'components/Page';

const PortalPage = (props) => {

  return (
    <Page
      className="DashboardPage"
      title="Portal"
      breadcrumbs={[{ name: 'Portal', active: true }]}
    >
      
    </Page>
  );
}

const mapStateToProps = (state) => {
  return {
  };
};

const mapActionToProps = {

};

export default connect(mapStateToProps, mapActionToProps)(PortalPage);
