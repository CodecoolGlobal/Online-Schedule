import React, { Component } from "react";
import Missing from "./Missing.js";
import Modal from './modal.js';

class Dashboard extends Component {
  constructor() {
    super();
    this.state = {
      show: false
    };
    this.showModal = this.showModal.bind(this);
    this.hideModal = this.hideModal.bind(this);
  }

  showModal = () => {
    this.setState({ show: true });
  };

  hideModal = () => {
    this.setState({ show: false });
  };
  render() {
    return (
      <>
        <Modal show={this.state.show} handleClose={this.hideModal} children={<Missing></Missing>} >
          
        </Modal>
        <button type="button" onClick={this.showModal}>
          +
        </button>
      </>
    );
  }
}


export default Dashboard