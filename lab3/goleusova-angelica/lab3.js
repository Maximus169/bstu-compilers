const lines = [
  "X = 1 + 2 * y; Z = 17;",
  "k1 = 23 * 25.17 - item;",
  "pi = (item - k) / 17 * k - (x2 * k);",
  "Result12 = (12 - 33) / K17;",
];

const dividerChars = ['=', '+', '-', '*', '/', '(', ')'];

// Разделяем строку по заданным в dividerChars символам на массив
const divide = (str) => {
  let result = [];

  // Начальная и конечная позиции отдельной лексемы
  let startPosition = 0, endPosition = 0;

  // Перебираем строку, смотрим заканчивается ли на разделитель.
  for (let i = 0; i < str.length; i++) {
    if (dividerChars.includes(str.charAt(i))) {

      // Обновляем конечную поцизию, пушим в результаты литерал до позиции и сам разделитель
      endPosition = i;
      result.push(str.slice(startPosition, endPosition));
      result.push(str.charAt(i));

      // Новая начальная позиция -> следующий за разделителем символ
      startPosition = i + 1;
    }
  }

  // Пушим последний литерал в строке
  result.push(str.slice(startPosition, str.length));
  return result;
};

/**
 * Принимает отдельный литерал и анализирует его (заполняет вторую и третью колонки)
 * @param literal - сам литерал/лексема (например 0.5 или x1)
 * @param items - массив уже обработанных лексем
 * @returns {{value: string}} - полученная в результате анализа информация о лексеме
 */
const analyseLiteral = (literal, items) => {
  const result = { value: '' };

  // Определяем тип литерала
  if (/^[a-zA-Z]+[a-zA-Z0-9]*$/.test(literal)) {
    result.type = "Идентификатор";
  } else if (literal.trim() === '(' || literal.trim() === ')') {
    result.type = "Скобка";
  } else if (/^[0-9]+$/.test(literal)) {
    result.type = "Целочисленная константа";
  } else if (/^[0-9]+[.][0-9]+$/.test(literal)) {
    result.type = "Вещественная константа";
  } else if (/^[+\-*/]+$/.test(literal)) {
    result.type = "Знак арифметической операции";
  } else if (/^[=]+$/.test(literal)) {
    result.type = "Знак присваивания";
  }

  // Определяем значение
  if (result.type === "Целочисленная константа" || result.type === "Вещественная константа") {
    result.value = literal;
  } else if (result.type === "Идентификатор") {
    let numberOfIdentifiers = items
      .filter((item) => item["Тип лексемы"] === "Идентификатор")
      .map((item) => item["Значение"])
      .filter((item, index, array) => array.indexOf(item) === index)
      .length;
    let isSameFound = false;

    // Подсчитываем, есть ли уже такие идентификаторы
    for (const item of items) {
      if (item["Тип лексемы"] === "Идентификатор") {
        const values = item["Значение"].split(':');
        if (values[0] === literal) {
          result.value = item["Значение"];
          isSameFound = true;
          break;
        }
      }
    }

    // Если такого идентификатора не нашли, просто записываем выражение в первый раз
    if (!isSameFound) {
      result.value = `${literal}:${numberOfIdentifiers + 1}`;
    }
  }

  return result;
};

const parse = (line) => {
  // Разделяем выражения по ';'
  const expressions = line.split(';');
  for (let expression of expressions) {

    // Проверяем что выражение не пустое (удалив пробелы в начале и конце строки)
    if (expression.trim()) {
      const result = [];
      console.log(`Исходное выражение: ${expression}`);

      // разделяем выражение по арифметическим символам и удаляем пробелы
      const literals = divide(expression).map(i => i.trim()).filter(i => !!i);

      // Перебираем массив литералов и анализируем каждый из них
      for (let literal of literals) {
        const analysedLiteral = analyseLiteral(literal, result);
        result.push({
          "Лексема": literal,
          "Тип лексемы": analysedLiteral.type,
          "Значение": analysedLiteral.value,
        });
      }

      // Выводим таблицу
      console.table(result, ["Лексема", "Тип лексемы", "Значение"]);
      console.log();
    }
  }
};

// Анализируем массив входных строк
const main = () => {
  for (let line of lines) {
    parse(line);
  }
};

main();
