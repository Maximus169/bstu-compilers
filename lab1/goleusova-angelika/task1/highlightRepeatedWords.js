function highlightRepeatedWords(str) {
  const matches = str.match(/\b(\w+)\b(?=.*?\b\1\b)/uig);
  let result = str;
  for (let match of matches) {
    const lastIndex = result.lastIndexOf(match);
    result = result.substring(0, lastIndex) + '\*\*' + match + '\*\*' + result.substring(lastIndex + match.length);
  }
  return result;
}

let args = process.argv.slice(2);

if (args[0]) {
  console.log(highlightRepeatedWords(args[0]));
} else {
  console.error("Не передан входной аргумент!");
}
