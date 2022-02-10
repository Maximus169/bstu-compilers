import {Button, TextField} from "@mui/material";
import {useState} from "react";

function Task2() {
  const [value, setValue] = useState('');
  const [isError, setIsError] = useState(false);

  const isEmail = (email) => {
    const re = /^([a-z0-9_-]+\.)*[a-z0-9_-]+@[a-z0-9_-]+(\.[a-z0-9_-]+)*\.[a-z]{2,6}$/;
    setIsError(!re.test(email));
  }

  const onChange = (e) => {
    setValue(e.target.value);
  }

  return (
    <div>
      <h2>Введите Email:</h2>
      <TextField
        id="standard-basic"
        onChange={onChange}
        label="Email"
        variant="standard"/>
      <br/>
      {isError && (
        <span style={{color: 'red', fontSize: '13px'}}>Некорректый Email</span>
      )}
      <br/>
      <Button
        onClick={() => isEmail(value)}
        variant="outlined">Submit
      </Button>
    </div>
  );
}

export default Task2;
