import { createStore } from "redux";
import produce from "immer";

const initialState = {
  data: [
    ["time", "rpm"],
    ["10:00", 50],
    ["10:15", 60],
    ["10:30", 50],
    ["10:45", 80],
    ["11:00", 30],
    ["11:03", 100]
  ],
  widgets: new Set(["table", "graph"])
};

const reducer = produce((state, action) => {
  switch (action.type) {
    case "SET_VALUE":
      setValue(state, action.payload);
      break;

    case "TOGGLE_WIDGET":
      if (state.widgets.has(action.payload)) {
        state.widgets.delete(action.payload);
      } else {
        state.widgets.add(action.payload);
      }
      break;

    default:
      break;
  }
}, initialState);

function setValue(state, { time, rpm }) {
  let item = state.data.find(el => el[0] === time);
  if (item) {
    item[1] = rpm;
  } else {
    state.data.push([time, rpm]);
  }
}

const store = createStore(reducer);
window.store = store;
export default store;
