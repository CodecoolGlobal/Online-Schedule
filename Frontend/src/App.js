import About from "./About";
import Missing from "./Missing";
import Layout from "./Layout";
import Teams from "./Teams";
import Team from "./Team";
import Home from "./Home";
import Demos from "./Demos";
import JobHunters from "./JobHunters";
import InterviewPrep from "./InterviewPrep";
import "./App.css";
import { Route, Routes } from "react-router-dom";
import {DataProvider} from "./dataContext/dataContext";

function App() {
  return (
    <DataProvider>
    <Routes>
      <Route path="/" element={<Layout />}>
        <Route index element={<Home />} />
        <Route path="teams">
          <Route index element={<Teams />} />
          <Route path=":id" element={<Team/>} />
        </Route>
        <Route path="demos">
          <Route index element={<Demos />} />
        </Route>
        <Route path="jobhunters">
          <Route index element={<JobHunters />} />
        </Route>
        <Route path="interviewprep" element={<InterviewPrep />} />
        <Route path="about" element={<About />} />
        <Route path="*" element={<Missing />} />
      </Route>
    </Routes>
    </DataProvider>
  );
}

export default App;
