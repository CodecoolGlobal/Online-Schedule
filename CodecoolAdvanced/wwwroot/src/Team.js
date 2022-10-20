import { useState } from 'react';
import { useParams } from 'react-router';
import useAxiosFetch from './hooks/useAxiosFetch';
import api from './api/api';

const Team = () => {
  const { id } = useParams();
  let url = `https://localhost:7086/api/teams/${id}`;
  const { data, fetchError, isLoading } = useAxiosFetch(url);
  console.log(data);

  const [siStart, setSiStart] = useState('');
  const [siFinish, setSiFinish] = useState('');
  const [twStart, setTwStart] = useState('');
  const [twFinish, setTwFinish] = useState('');

  const handleSiStart = async (e) => {
    e.preventDefault();
    try {
      const review = siStart.replace(':', '%3A')
      const response = await api.put(`/teams/${id}/si/start?siReviewStart=${review}`);
      setSiStart('');
    } catch (err) {
      if (err.response) {
        console.log(err.response.data);
        console.log(err.response.status);
        console.log(err.response.headers);
      } else {
        console.log(`Error: ${err.message}`);
      }
      
    }
  };
  const handleSiFinish = async (e) => {
    e.preventDefault();
    try {
      const review = siFinish.replace(':', '%3A')
      const response = await api.put(`/teams/${id}/si/finish?siReviewFinish=${review}`);
      setSiFinish('');
    } catch (err) {
      if (err.response) {
        console.log(err.response.data);
        console.log(err.response.status);
        console.log(err.response.headers);
      } else {
        console.log(`Error: ${err.message}`);
      }
      
    }
  };
  const handleTwStart = async (e) => {
    e.preventDefault();
    try {
      const review = twStart.replace(':', '%3A')
      const response = await api.put(`/teams/${id}/tw/start?twReviewStart=${review}`);
      setTwStart('');
    } catch (err) {
      if (err.response) {
        console.log(err.response.data);
        console.log(err.response.status);
        console.log(err.response.headers);
      } else {
        console.log(`Error: ${err.message}`);
      }
      
    }
  };
  const handleTwFinish = async (e) => {
    e.preventDefault();
    try {
      const review = twFinish.replace(':', '%3A')
      const response = await api.put(`/teams/${id}/tw/finish?twReviewFinish=${review}`);
      setTwFinish('');
    } catch (err) {
      if (err.response) {
        console.log(err.response.data);
        console.log(err.response.status);
        console.log(err.response.headers);
      } else {
        console.log(`Error: ${err.message}`);
      }
      
    }
  };
  return (
    <>
      {' '}
      {isLoading && <p className="statusMsg">Loading ...</p>}
      {!isLoading && fetchError && (
        <p className="statusMsg" style={{ color: 'red' }}>
          {fetchError}
        </p>
      )}
      {!isLoading && !fetchError && (
        <>
          <h1>{data.name}</h1>
          <div>Mentor: {data.mentor}</div>
          <ul>
            Students:
            {data.students?.map((student) => (
              <li key={student.id}>{student.name}</li>
            ))}
          </ul>
        </>
      )}
      <a href={data.repo}>Repository</a>
      <div>
        SI review start:{' '}
        {data.siReviewStart === null
          ? 'not set yet'
          : data.siReviewStart}
      </div>
      <form onSubmit={handleSiStart}>
        <label>
          SI review start:
          <input
            id="siStart"
            type="time"
            required
            value={siStart}
            onChange={(e) => setSiStart(e.target.value)}
          />
        </label>
        <input type="submit" value="Submit" />     
      </form>
      <div>
        SI review finish:{' '}
        {data.siReviewFinish === null
          ? 'not set yet'
          : data.siReviewFinish}
      </div>


      <form onSubmit={handleSiFinish}>
        <label>
          SI review finish:
          <input 
          id="siFinish"
            type="time"
            required
            value={siFinish}
            onChange={(e) => setSiFinish(e.target.value)} />
        </label>
        <input type="submit" value="Submit" />
      </form>
      <div>
        TW review start:{' '}
        {data.twReviewStart === null
          ? 'not set yet'
          : data.twReviewStart}
      </div>


      <form onSubmit={handleTwStart}>
        <label>
          TW review start:
          <input 
            id="twStart"
            type="time"
            required
            value={twStart}
            onChange={(e) => setTwStart(e.target.value)} />
        </label>
        <input type="submit" value="Submit" />
      </form>
      <div>
        TW review finish:{' '}
        {data.twReviewFinish === null
          ? 'not set yet'
          : data.twReviewFinish}
      </div>


      <form onSubmit={handleTwFinish}>
        <label>
          TW review finish:
          <input 
            id="twFinish"
            type="time"
            required
            value={twFinish}
            onChange={(e) => setTwFinish(e.target.value)} />
        </label>
        <input type="submit" value="Submit" />
      </form>
    </>
  );
};

export default Team;
