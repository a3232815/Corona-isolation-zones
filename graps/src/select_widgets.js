import React from "react";
import { connect } from "react-redux";
import { toggleWidget } from "./redux/actions";

export default connect(state => ({ widgets: state.widgets }))(
  function WidgetSelector(props) {
    const { widgets, dispatch } = props;

    const supportedWidgets = ["table", "graph"];

    return (
      <ul>
        {supportedWidgets.map(w => (
          <li>
            <label>
              <input
                type="checkbox"
                checked={widgets.has(w)}
                onChange={e => dispatch(toggleWidget(w))}
              />
              {w}
            </label>
          </li>
        ))}
      </ul>
    );
  }
);
