import { Button } from "bootstrap";
import { Table } from "reactstrap";



const ContactsTable = ({ data }) => {
    return (
        <Table striped responsive>
            <thead>
                <tr>
                    <th>Name</th>
                    <th>Email</th>
                    <th>Phone</th>
                    <th></th>
                </tr>
            </thead>
            <tbody>
                {
                    (data.length < 1) ? (
                        <tr>
                            <td colSpan="4"> No Register</td>
                        </tr>
                    ) : (

                        data.map((item) =>
                            <tr key={item.contactId}>
                                <td>{item.contactName}</td>
                                <td>{item.email}</td>
                                <td>{item.phone}</td>
                                <td>
                                    <Button color="primary" size="sm" className="me-2">Edit</Button>
                                    <Button color="danger" size="sm">Delete</Button>
                                </td>

                            </tr>
                        )
                    )
                }
            </tbody>
        </Table >
    )
}

export default ContactsTable;