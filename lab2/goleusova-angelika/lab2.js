const srcTable = [
  {
    id: "a23b24c",
    memory: 15,
  },
  {
    id: "b23754c",
    memory: 16,
  },
  {
    id: "124c",
    memory: 1,
  },
  {
    id: "424c",
    memory: 3,
  },
  {
    id: "2342c",
    memory: 5,
  },
  {
    id: "43324c",
    memory: 12,
  },
  {
    id: "113b24c",
    memory: 14,
  },
  {
    id: "5434c",
    memory: 12,
  },
  {
    id: "434b24c",
    memory: 11,
  },
];

const sortedTable = [...srcTable];

sortedTable.sort((a, b) =>
  (a.id > b.id) ? 1 : ((b.id > a.id) ? -1 : 0));

let sumOfIterations = 0;
for (let item of srcTable) {
  for (let i = 0; i < sortedTable.length; i++) {
    if (item.id === sortedTable[i].id) {
      console.log(`Найден идентификатор ${item.id}, количество итераций ${i + 1}`);
      sumOfIterations = i + 1 + sumOfIterations;
      break;
    }
  }
}
console.log(`Среднее количество итераций ${sumOfIterations / sortedTable.length}`);
