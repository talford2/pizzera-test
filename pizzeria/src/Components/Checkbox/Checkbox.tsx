import React from "react";
import "./Checkbox.css";

export interface ICheckboxProps {
  label: string;
  checked: boolean;
  data?: any;
  onChange: (checked: boolean, data: any) => void;
}

export const Checkbox = (props: ICheckboxProps) => {
  const [checked, setChecked] = React.useState<boolean>(props.checked);

  const handleClick = () => {
    const newValue = !checked;
    setChecked(newValue);
    props.onChange(newValue, props.data);
  };

  return (
    <div className={"checkbox" + (checked ? " checked" : "")}>
      <span className="box" onClick={handleClick}></span>
      <label onClick={handleClick}>{props.label}</label>
    </div>
  );
};
