import { useState } from "react";
import { Modal, Form, FormGroup, Input, Label, ModalBody, ModalHeader, ModalFooter, Button } from "reactstrap";

const contactModel = {
    contactId: 0,
    contactName: "",
    email: "",
    phone: ""
}


const ContactModal = ({ showModal, setShowModal, saveContact }) => {

    const [contact, setContact] = useState(contactModel);
    const updateData = (e) => {
        setContact(
            {
                ...contact,
                [e.target.name]: e.target.value
            }
        )
    }

    const sendingData = () => {
        if (contact.contactId == 0) {
            saveContact(contact)
        }
    }

    return (
        <Modal isOpen={showModal}>
            <ModalHeader>
                New Contact
            </ModalHeader>
            <ModalBody>
                <Form>
                    <FormGroup>
                        <Label>Name</Label>
                        <Input name="contactName" onChange={(e) => updateData(e)} value={contact.contactName} ></Input>
                    </FormGroup>
                    <FormGroup>
                        <Label>Email</Label>
                        <Input name="email" onChange={(e) => updateData(e)} value={contact.email}></Input>
                    </FormGroup>
                    <FormGroup>
                        <Label>Phone</Label>
                        <Input name="phone" onChange={(e) => updateData(e)} value={contact.phone}></Input>
                    </FormGroup>
                </Form>
            </ModalBody>
            <ModalFooter>
                <Button color="primary" size="sm" onClick={sendingData}>Save</Button>
                <Button color="danger" size="sm" onClick={() => setShowModal(!showModal)}>Close</Button>
            </ModalFooter>

        </Modal >
    )
}


export default ContactModal;