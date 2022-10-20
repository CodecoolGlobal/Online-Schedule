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
      const review = { siReviewStart: siStart };
      const response = await api.put(`/teams/${id}/si/start`, review);
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
        {data.siReviewStart === '0001-01-01T00:00:00'
          ? 'not set yet'
          : data.siReviewStart}
      </div>
      <form onSubmit={handleSiStart}>
        <label>
          SI review start:
          <input
            id="siStart"
            type="text"
            required
            value={siStart}
            onChange={(e) => setSiStart(e.target.value)}
          />
        </label>
        <input type="submit" value="Submit" />
      </form>
      <div>
        SI review finish:{' '}
        {data.siReviewFinish === '0001-01-01T00:00:00'
          ? 'not set yet'
          : data.siReviewFinish}
      </div>
      <form>
        <label>
          SI review finish:
          <input type="text" name="name" />
        </label>
        <input type="submit" value="Submit" />
      </form>
      <div>
        TW review start:{' '}
        {data.twReviewStart === '0001-01-01T00:00:00'
          ? 'not set yet'
          : data.twReviewStart}
      </div>
      <form>
        <label>
          TW review start:
          <input type="text" name="name" />
        </label>
        <input type="submit" value="Submit" />
      </form>
      <div>
        TW review finish:{' '}
        {data.twReviewFinish === '0001-01-01T00:00:00'
          ? 'not set yet'
          : data.twReviewFinish}
      </div>
      <form>
        <label>
          TW review finish:
          <input type="text" name="name" />
        </label>
        <input type="submit" value="Submit" />
      </form>
    </>
  );
};

export default Team;
