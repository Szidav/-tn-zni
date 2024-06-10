const { application } = require('express');
const express=require('express');
const sqlite3=require('sqlite3');
const cors=require('cors');
const db=new sqlite3.Database('./chinook.db');

const app=express();

app.use(express.json());
app.use(express.urlencoded({extended:true}));
app.use(cors());
app.listen(8000,()=>{console.log("Running")});

app.get('/',(req,res)=>{
    res.json("Backend vizsgafeladat");
});

app.get('/artists',(req,res)=>{
    db.all("SELECT * FROM artists"
    ,(error,rows)=>{
        if(error)
        {
            res.status(400).json({message:error.message});
        }
        else
        {
            res.status(200).json(rows);
        }
    })
});

/*app.post('/artists', (req, res) => {
    const { Name } = req.body;
    if (!Name) {
        res.status(400).json({ message: "Hiányzó név!" });
    } else {
        db.run("INSERT INTO artists (Name) VALUES (?)",
            [Name], function (err) {
                if (err) {
                    res.status(500).json({ error: err.message });
                } else {
                    res.status(201).json({ id: this.lastID, name: Name });
                }
            });
    }
});*/

app.post('/artists',(req,res)=>{
    const {Name} = req.body;
    if(!Name)
    {
        res.status(400).json("Hiányzó név!")
    }
    else
    {
        db.run("INSERT INTO artists (Name) VALUES (?)",
            [Name],
            function (err){
                if(err)
                {
                    res.status(500).json({error:err.message});
                }
                else
                {
                    res.status(201).json({id: this.lastID, name: Name});
                }
            }
        )
    }
});


app.get('/genre-tracks/:Name',(req,res)=>{
    const Name = req.params.Name
    
        db.all("SELECT t.* FROM genres g, tracks t WHERE g.GenreId = t.GenreId AND g.Name=?"
            ,[Name]
            ,(error,rows)=>{
                if(error)
                {
                    res.status(400).json({message:error.message})
                }
                else
                {
                    res.status(200).json(rows);
                }
            })
});

