import "bootstrap/dist/css/bootstrap.min.css"
import { useState } from "react"

const App = () => {
    /*
const [number, setNumber] = useState(0);
/*
    number = nombre de la variable para obtener el valor| obtener el estado actual
    setNumber = funcion que actualiza el valor | actualiza el estado
*/
    /*
        EJEMPLO DE USE STATE
     let person = {
         Name: "Soel",
         EMail: "soel@gmail.com"
     }
    
     const [person1, setPerson] = useState(person);
    
    
    
    
    
     return (<div className="container-fluid">
         <h1> Actual number value: {number}</h1>
         <button onClick={() => setNumber(number + 1)}>
             Upgrade value</button>
    
         <br></br>
         <br></br>
         <p>Nombre{person1.Name}</p>
         <p>Email:{person1.EMail}</p>
         <button onClick={() => setPerson(
             {
                 ...person1,
                 EMail: "soela111@gmail.com"
             }
         )}>
             Cambiar E-Mail
         </button>
    
    
     </div >)
     */
    /*

            EJEMPLO DE USE EFECT
    const [name, setName] = useState("Soel")
    const writeInConsole = () => {
        setName("Maria")
        console.log("El nombre ha cambiado a:" + name)
    }
    return (
        <div className="container-fluid">
            <h1>El nombre actual es: "{name}"</h1>
            <button onClick = {writeInConsole}>
                Cambiar Nombre
            </button>
        </div>
    )
    */


    return (
        <div className="container-fluid">

        </div>
    )



}

export default App;
