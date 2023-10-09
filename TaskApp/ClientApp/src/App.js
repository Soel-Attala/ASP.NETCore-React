import "bootstrap/dist/css/bootstrap.min.css"
import { useEffect, useState } from "react";


const App = () => {

    const [tasks, setTasks] = useState([])
    const [description, setDescription] = useState("");


    const showTasks = async () => {
        const response = await fetch("api/tasks/List");
        if (response.ok) {
            const data = await response.json();
            setTasks(data);
        } else {
            console.log("Status Code: " + response.status);
        }
    }

    const formatDate = (string) => {
        let options = { year: 'numeric', month: 'long', day: 'numeric' };
        let date = new Date(string).toLocaleDateString("es-AR", options);
        let hour = new Date(string).toLocaleString();
        return date + " | " + hour;
    }

    useEffect(() => {
        showTasks();
    }, [])


    const saveTask = async (e) => {
        e.preventDefault()
        const response = await fetch("api/tasks/save/", {
            method: "POST",
            headers: {
                'Content-Type': 'application/json;charset=utf-8'
            },
            body: JSON.stringify({ description: description })
        })

        if (response.ok) {
            setDescription("");
            await showTasks();
        }
    }

    const endTask = async (id) => {

        const response = await fetch("api/tasks/delete/" +id, {
            method: "DELETE",

        })

        if (response.ok) {
            await showTasks();
        }
    }





    return (
        <div className="container bg-dark p-4 vh-100">

            <h2 className="text-white"> Tasks List</h2>
            <div className="row">
                <div className="col-sm-12">
                    <form onSubmit={saveTask}>
                        <div className="input-group">
                            <input type="text" className="form-control" placeholder="Please set a description for your task" value={description} onChange={(e) => setDescription(e.target.value)} />
                            <button className="btn btn-success" type="submit"> New Task</button>
                        </div>
                    </form>
                </div>
            </div>
            <div className="row mt-4">
                <div className="col-sm-12">
                    <div className="list-group">
                        {
                            tasks.map(
                                (item) => (
                                    <div key={item.idTask} className="list-group-item list-group-item-action">
                                        <h5 className="text-primary">{item.description}</h5>
                                        <div className="d-flex justify-content-between">
                                            <small className="text-muted">{formatDate(item.registerDate)}</small>
                                            <button onClick={()=>endTask(item.idTask)} className="btn btn-sm btn-outline-danger">End Task</button>
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
