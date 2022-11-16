import React from "react";
import { useState } from "react";
import Modal from './modal.js';

const Dashboard= ({children})=> {

  const [show, setShow]= useState(false);

   
    
  

  const showModal = () => {
    setShow(true);
  };

  const hideModal = () => {
    setShow(false)
  };
    return (
      <>
        <Modal show={show} handleClose={hideModal} children={children}>
          
        </Modal>
        <button type="button" onClick={showModal}>
          +
        </button>
      </>
    );
  }



export default Dashboard