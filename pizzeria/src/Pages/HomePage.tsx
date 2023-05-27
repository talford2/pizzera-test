import { Checkbox } from "../Components/Checkbox/Checkbox";

export const HomePage = () => {
  const handleCheck = (b: boolean) => {
    console.log("b", b);
  };

  return (
    <section>
      <h2>Home</h2>
      <p>Welcome home!</p>

      <Checkbox label="Testing" onChange={handleCheck} checked={false} />
    </section>
  );
};
