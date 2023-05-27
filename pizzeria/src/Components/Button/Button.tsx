export interface IButtonProps {
  label: string;
  onClick?: () => void;
}

export const Button = (props: IButtonProps) => {
  return <button onClick={props.onClick}>{props.label}</button>;
};
