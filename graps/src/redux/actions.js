export function setTime(time, rpm) {
    return { type: "SET_TIME", payload: { time, rpm } };
  }
  
  export function toggleWidget(widget) {
    return { type: "TOGGLE_WIDGET", payload: widget };
  }
  