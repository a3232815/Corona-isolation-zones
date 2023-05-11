import React from "react";
import { connect } from "react-redux";
import {
  LineChart,
  Line,
  XAxis,
  YAxis,
  CartesianGrid,
  Tooltip,
  Legend
} from "recharts";

function toTimestamp(time) {
  return (
    Number(new Date("2020-01-01T" + time + "Z")) -
    Number(new Date("2020-01-01"))
  );
}

export default connect(mapStateToProps)(function Graph(props) {
  const { data } = props;
  const dataForLineChart = data.slice(1).map(row => ({ x: row[0], y: row[1] }));

  return (
    <LineChart
      width={500}
      height={300}
      data={dataForLineChart}
      margin={{
        top: 5,
        right: 30,
        left: 20,
        bottom: 5
      }}
    >
      <CartesianGrid strokeDasharray="3 3" />
      <XAxis dataKey="x" />
      <YAxis />
      <Tooltip />
      <Legend />
      <Line
        type="monotone"
        name={data[0][1]}
        dataKey="y"
        stroke="#8884d8"
        activeDot={{ r: 8 }}
      />
    </LineChart>
  );
});

function mapStateToProps(state) {
  return { data: state.data };
}
