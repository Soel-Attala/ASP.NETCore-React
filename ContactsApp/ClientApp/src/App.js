import { Container, Row, Card, CardHeader, Button, CardBody, Col } from "reactstrap";
import ContactsTable from "./components/ContactsTable";
import { useEffect, useState } from "react";
import ContactModal from "./components/ContactModal";

const App = () => {

    const [contacts, setContacts] = useState([])
    const [showModal, setShowModal] = useState(false)

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
                            <ContactsTable data={contacts} />

                        </CardBody>
                    </Card>
                </Col>
            </Row>
            <ContactModal
                showModal={showModal}
                setShowModal={setShowModal}
                saveContact={saveContact}
            />
        </Container >
    )
}

export default App;