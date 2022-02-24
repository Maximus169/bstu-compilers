import {Button, CircularProgress, Input} from "@mui/material";
import {useState} from "react";

const rules = [
  {exp: />(.*)/g, replaceOn: `<blockquote>$1</blockquote>`},
  {exp: /\*\*(.*)\*\*/g, replaceOn: `<b>$1</b>`},
  {exp: /`(.*)`/g, replaceOn: `<code>$1</code>`},
  {exp: /~~(.*)~~/g, replaceOn: `<s>$1</s>`},
  {exp: /\*(.*)/g, replaceOn: `<li>$1</li>`},
  {exp: /######(.*)/g, replaceOn: `<h6>$1</h6>`},
  {exp: /#####(.*)/g, replaceOn: `<h5>$1</h5>`},
  {exp: /####(.*)/g, replaceOn: `<h4>$1</h4>`},
  {exp: /###(.*)/g, replaceOn: `<h3>$1</h3>`},
  {exp: /##(.*)/g, replaceOn: `<h2>$1</h2>`},
  {exp: /#(.*)/g, replaceOn: `<h1>$1</h1>`},
];

function Task3() {

  const [value, setValue] = useState('');
  const [result, setResult] = useState('');
  const [loading, setLoading] = useState(false);

  const transform = () => {
    let res = value;
    for (let rule of rules) {
      res = res.replaceAll(rule.exp, rule.replaceOn);
    }
    setResult(res);
  }

  const handleFile = (event) => {
    if (event.target.files[0]) {
      setLoading(true);
      let reader = new FileReader();
      reader.onload = (e) => {
        setValue(String(e.target.result));
        setLoading(false);
      };
      reader.readAsText(event.target.files[0]);
    }
  }

  return (
    <div style={{width: '100%'}}>
      <h1>Трансформация из Markdown файла в HTML страницу</h1>
      {loading && <CircularProgress/>}
      <Input
        onChange={handleFile}
        variant="outlined"
        type='file'
      />
      <br/>
      <br/>
      <Button
        onClick={transform}
        variant="outlined">
        Трансформировать
      </Button>
      <h1>Результат:</h1>
      <div>{result.split('\n').map((item, index) =>
        (<p key={index} dangerouslySetInnerHTML={{__html: item}} />))}</div>
    </div>
  );
}

export default Task3;
