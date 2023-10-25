import { Container, Row, Card, CardHeader, Button, CardBody, Col } from "reactstrap";
import ContactsTable from "./components/ContactsTable";
import { useEffect, useState } from "react";

const App = () => {

    const [contacts, setContacts] = useState([])

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

    return (
        <Container>
            <Row className="mt-5">
                <Col sm="12">
                    <Card>
                        <CardHeader>
                            <h5>Contact List</h5>
                        </CardHeader>
                        <CardBody>
                            <Button size="sm" color="success">New Contact</Button>
                            <hr></hr>
                            <ContactsTable data={contacts} />

                        </CardBody>
                    </Card>
                </Col>
            </Row>
        </Container >
    )
}

export default App;