import React from "react";
import ReactDOM from "react-dom";
// npm install --save-dev react-redux
import { Provider, connect } from "react-redux";
import store from "./redux/store";
import Table from "./widgets/table";
import Graph from "./widgets/graph";
import SelectWidgets from "./select_widgets";

const Main = connect(state => ({ widgets: state.widgets }))(function Main(
  props
) {
  const { widgets } = props;

  return (
    <>
      {widgets.has("table") && <Table />}
      {widgets.has("graph") && <Graph />}
    </>
  );
});

const App = props => (
  <Provider store={store}>
    <div className="container">
      <div className="row">
        <div className="col-3">
          <SelectWidgets />
        </div>
        <div className="col-9">
          <Main className="col-9" />
        </div>
      </div>
    </div>
  </Provider>
);

const rootElement = document.getElementById("root");
ReactDOM.render(<App />, rootElement);
