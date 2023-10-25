import { Container, Row, Card, CardHeader, Button, CardBody, Col } from "reactstrap";
import ContactsTable from "./components/ContactsTable";
import { useEffect, useState } from "react";
import ContactModal from "./components/ContactModal";

const App = () => {

    const [contacts, setContacts] = useState([])
    const [showModal, setShowModal] = useState(false)
    const [edit, setEdit] = useState(null);

    const showContacts = async () => {
        const response = await fetch("/api/contact/List");
        if (response.ok) {
            const data = await response.json();
            setContacts(data)
        } else {
            console.log("Status Code: " + response.status)
        }
    }

    useEffect(() => {
        showContacts()
    }, [])

    const saveContact = async (contact) => {
        const response = await fetch("api/contact/Save", {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json;charset=utf-8'
            },
            body: JSON.stringify(contact)
        })

        if (response.ok) {
            setShowModal(!showModal);
            showContacts();
        }
    }

    const editContact = async (contact) => {
        const response = await fetch("api/contact/Edit", {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json;charset=utf-8'
            },
            body: JSON.stringify(contact)
        })

        if (response.ok) {
            setShowModal(!showModal);
            showContacts();
        }
    }


    const deleteContact = async (id) => {

        var answer = window.confirm("Do you want to delete this contact?")
        if (!answer) {
            return;
        }
        const response = await fetch("api/contact/Delete/" + id, {
            method: 'DELETE'
        })
        

        if (response.ok) {
            showContacts();
        }
    }




    return (
        <Container>
            <Row className="mt-5">
                <Col sm="12">
                    <Card>
                        <CardHeader>
                            <h5>Contact List</h5>
                        </CardHeader>
                        <CardBody>
                            <Button size="sm" color="success" onClick={() => setShowModal(!showModal)}>New Contact</Button>
                            <hr></hr>
                            <ContactsTable data={contacts}
                                setEdit={setEdit}
                                showModal={showModal}
                                setShowModal={setShowModal}
                                deleteContact={deleteContact }
                            />

                        </CardBody>
                    </Card>
                </Col>
            </Row>
            <ContactModal
                showModal={showModal}
                setShowModal={setShowModal}
                saveContact={saveContact}

                edit={edit}
                setEdit={setEdit}
                editContact={editContact}
            />
        </Container >
    )
}

export default App;