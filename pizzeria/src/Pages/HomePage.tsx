import { Link } from "react-router-dom";

export const HomePage = () => {
  return (
    <section>
      <h2>Home</h2>
      <p>
        Welcome, go to the <Link to="/restaurants">restaurants</Link> page to
        see the menu
      </p>
    </section>
  );
};
