import Vevo from "./Vevo"
import { useState,useEffect } from "react"

function Vevok() {

    const [vevok,setVevok]=useState([]);

    useEffect(()=>{
        fetch("http://localhost:8000/vevok")
        .then(res=>res.json())
        .then(vevok=>setVevok(vevok))
        .catch(err=>alert(err));
    });

  return (
    <div>
        <h1 className="text-3xl font-bold text-center text-indigo-500 m-5">A webshop eddigi vevői</h1>
        <div className="grid lg:grid-cols-4 md:grid-cols-2 sm:grid-cols-1">
            {
                vevok.map((vevo,i)=><Vevo key={i} vevo={vevo}/>)
            }
        </div>
    </div>
  )
}

export default Vevok