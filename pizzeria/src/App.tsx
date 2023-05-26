import './App.css';
import { Link, Route, Routes } from 'react-router-dom';
import { HomePage } from './Pages/HomePage';
import { RestaurantsPage } from './Pages/RestaurantsPage';
import { RestaurantPage } from './Pages/RestaurantPage';

function App() {
  return (
    <main>
    <header>
      <h1>Pizzeria</h1>
      <nav>
        <ul>
          <li><Link to="/">Home</Link></li>
          <li><Link to="/restaurants">Restaurants</Link></li>
        </ul>
      </nav>
    </header>
    <Routes>
      <Route path="/" element={<HomePage />} />
      <Route path="/restaurants" element={<RestaurantsPage />} />
      <Route path="/restaurants/:id" element={<RestaurantPage />} />
    </Routes>
    </main>
  );
}

export default App;
