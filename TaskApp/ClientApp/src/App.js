import "bootstrap/dist/css/bootstrap.min.css"
import { useEffect, useState } from "react";


const App = () => {

    const [tasks, setTasks] = useState([])

    const showTasks = async () => {
        const response = await fetch("api/tasks/List");
        if (response.ok) {
            const data = await response.json();
            setTasks(data);
        } else {
            console.log("Status Code: " + response.status);
        }
    }

    useEffect(() => {
        showTasks();
    }, [])







    return (
        <div className="container bg-dark p-4 vh-100">

            <h2 className="text-white"> Tasks List</h2>
            <div className="row">
                <div className="col-sm-12"></div>
            </div>
            <div className="row mt-4">
                <div className="col-sm-12">
                    <div className="list-group">
                        {
                            tasks.map(
                                (item) => (
                                    <div className="list-group-item list-group-item-action">
                                        <h5 className="text-primary">{item.description}</h5>
                                        <div class="d-flex justify-content-between">

                                        </div>


                                    </div>
                                )
                            )
                        }
                    </div>

                </div>
            </div>
        </div>
    )
}

export default App;
