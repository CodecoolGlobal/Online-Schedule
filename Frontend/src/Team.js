import { useState, useEffect } from 'react';
import { useParams } from 'react-router';
import useAxiosFetch from './hooks/useAxiosFetch';
import api from './hooks/api';

const Team = () => {
  const { id } = useParams();
  let url = `https://localhost:7086/api/teams/${id}`;

  const { data, fetchError, isLoading } = useAxiosFetch(url);
  console.log(data);

  const [siStart, setSiStart] = useState('');
  const [siFinish, setSiFinish] = useState('');
  const [twStart, setTwStart] = useState('');
  const [twFinish, setTwFinish] = useState('');

  useEffect(() => {
    setSiStart(data.siReviewStart);
    setSiFinish(data.siReviewFinish);
    setTwStart(data.twReviewStart);
    setTwFinish(data.twReviewFinish);
  }, [data]);
  const handleSiStart = async (e) => {
    e.preventDefault();
    try {
      const review = siStart.replace(':', '%3A');
      const response = await api.put(
        `/teams/${id}/si/start?siReviewStart=${review}`
      );
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
      const review = siFinish.replace(':', '%3A');
      const response = await api.put(
        `/teams/${id}/si/finish?siReviewFinish=${review}`
      );
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
      const review = twStart.replace(':', '%3A');
      const response = await api.put(
        `/teams/${id}/tw/start?twReviewStart=${review}`
      );
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
      const review = twFinish.replace(':', '%3A');
      const response = await api.put(
        `/teams/${id}/tw/finish?twReviewFinish=${review}`
      );
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
        <div className='design'></div>
          <h1 className='teamName'>{data.name} ({data.students?.map((student) => (
              student.name + " "
            ))})</h1>
        </>
      )}
      
      <div className='teamContainer'>
      <div>Mentor: {data.mentor}</div>
      <a href={data.repo}><div className='repo'>Repository</div></a>
      <div className='flex'>
      <div className='time'>
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
        <input type="submit" value="Submit" className='sub' />
      </form>
      </div>
      <div className='time'>
      <form onSubmit={handleSiFinish}>
        <label>
          SI review finish:
          <input
            id="siFinish"
            type="time"
            required
            value={siFinish}
            onChange={(e) => setSiFinish(e.target.value)}
          />
        </label>
        <input type="submit" value="Submit" className='sub' />
      </form>
      </div>
      <div className='time'>
      <form onSubmit={handleTwStart}>
        <label>
          TW review start:
          <input
            id="twStart"
            type="time"
            required
            value={twStart}
            onChange={(e) => setTwStart(e.target.value)}
          />
        </label>
        <input type="submit" value="Submit" className='sub' />
      </form>
      </div>
      <div className='time'>
      <form onSubmit={handleTwFinish}>
        <label>
          TW review finish:
          <input
            id="twFinish"
            type="time"
            required
            value={twFinish}
            onChange={(e) => setTwFinish(e.target.value)}
          />
        </label>
        <input type="submit" value="Submit" className='sub'  />
      </form>
      </div>
      </div>
      </div>
    </>
  );
};

export default Team;
