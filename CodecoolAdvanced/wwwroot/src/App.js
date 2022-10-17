import About from "./About";
import Missing from "./Missing";
import Layout from "./Layout";
import Teams from "./Teams";
import Home from "./Home";
import "./App.css";
import { Route, Routes } from "react-router-dom";


function App() {
  return (
    <Routes>
      <Route path="/" element={<Layout />}>
        <Route index element={<Home />} />
        <Route path="teams">
          <Route index element={<Teams />} />
        </Route>
        <Route path="about" element={<About />} />
        <Route path="*" element={<Missing />} />
      </Route>
    </Routes>
  );
}

export default App;
