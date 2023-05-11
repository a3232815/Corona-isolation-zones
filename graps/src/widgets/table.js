import React from "react";
import { connect } from "react-redux";

export default connect(mapStateToProps)(function(props) {
  const { data } = props;
  return (
    <table className="table">
      <thead>
        <tr>
          {data[0].map((col, idx) => (
            <th key={idx}>{col}</th>
          ))}
        </tr>
      </thead>
      <tbody>
        {data.slice(1).map((row, ri) => (
          <tr key={ri}>
            {row.map((col, idx) => (
              <td key={idx}>{col}</td>
            ))}
          </tr>
        ))}
      </tbody>
    </table>
  );
});

function mapStateToProps(state) {
  return { data: state.data };
}


