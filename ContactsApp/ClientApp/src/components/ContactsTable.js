import { Table, Button } from "reactstrap";



const ContactsTable = ({ data, setEdit, showModal, setShowModal,deleteContact }) => {


    const sendData = (contact) => {
        setEdit(contact)
        setShowModal(!showModal)
    }

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
                                    <Button color="primary" size="sm" className="me-2" onClick={()=>sendData(item) }>Edit</Button>
                                    <Button color="danger" size="sm" onClick={()=>deleteContact(item.contactId) }>Delete</Button>
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