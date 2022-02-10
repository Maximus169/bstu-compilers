import {Button, TextField} from "@mui/material";
import {useEffect, useState} from "react";

const defaultValue = `
Это обычный текст
**Этот текст будет жирным**
Этот текст содержит кусок \`function(12);\` кода
~~Этот текст будет зачеркнутым~~
*Это 1ый элемент списка
*Это 2ой элемент списка
# Это самый крупный заголовок
## Заголовок 2
### Заголовок 3
#### Заголовок 4
##### Заголовок 5
###### Заголовок 6
> Это мудрая цитата
`;

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

  useEffect(() => {
    setValue(defaultValue);
  }, []);

  const onChange = (e) => {
    setValue(e.target.value);
  }

  const transform = () => {
    let res = value;
    for (let rule of rules) {
      res = res.replaceAll(rule.exp, rule.replaceOn);
    }

    setResult(res);
  }

  return (
    <div style={{width: '50%'}}>
      <h2>Введите Markdown текст:</h2>
      <TextField
        id="standard-basic"
        multiline
        onChange={onChange}
        label="Text"
        defaultValue={defaultValue}
        variant="standard"
        style={{width: '90%'}}
      />
      <br/>
      <br/>
      <Button
        onClick={transform}
        variant="outlined">
        Transform
      </Button>
      <p>Result:</p>
      <div>{result.split('\n').map((item, index) => (<p key={index}>{item}</p>))}</div>
    </div>
  );
}

export default Task3;
