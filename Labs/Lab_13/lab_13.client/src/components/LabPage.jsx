import { useEffect, useState } from 'react';
import axios from 'axios';
import PropTypes from 'prop-types';

const LabPage = ({ labNumber }) => {
    const [labData, setLabData] = useState(null);
    const [inputContent, setInputContent] = useState('');
    const [outputContent, setOutputContent] = useState('');
    const [actionName, setActionName] = useState('');

    useEffect(() => {
        const fetchLabData = async () => {
            try {
                const response = await axios.get(`https://localhost:7258/api/labs/lab${labNumber}`);
                setLabData(response.data);
                setActionName(response.data.actionName); 
            } catch (error) {
                console.error('Error fetching lab data:', error);
            }
        };

        setInputContent('');
        setOutputContent('');
        fetchLabData();
    }, [labNumber]);

    const handleFileChange = (e) => {
        const file = e.target.files[0];
        const reader = new FileReader();
        reader.onload = (event) => {
            setInputContent(event.target.result);
        };
        reader.readAsText(file);
    };

    const handleFormSubmit = async (e) => {
        e.preventDefault();
        const formData = new FormData();

        const inputFile = e.target.elements.inputFile.files[0];
        formData.append('inputFile', inputFile);
        formData.append('actionName', actionName); 

        try {
            const response = await axios.post('https://localhost:7258/api/Labs/run', formData, {
                headers: {
                    'Content-Type': 'multipart/form-data',
                },
            });

            if (response.data?.result) {
                setOutputContent(response.data.result);
            } else {
                console.error('Unexpected response format:', response.data);
                throw new Error('Unexpected response format');
            }
        } catch (error) {
            console.error('Error during form submission:', error);
            alert('Error: ' + (error.response?.data?.Error || error.message));
        }
    }

    if (!labData) {
        return <p>Loading...</p>;
    }

    return (
        <div className="container mt-4">
            <div className="card shadow-sm">
                <div className="card-header">
                    <h2>Lab n. {labData.labNumber}</h2>
                </div>

                <div className="card-body">
                    <section>
                        <h5>Task:</h5>
                        <p>{labData.description}</p>
                    </section>

                    <section>
                        <h5>Input Data:</h5>
                        <p>{labData.inputDescription}</p>

                        <h5>Output Data:</h5>
                        <p>{labData.outputDescription}</p>
                    </section>

                    <section className="mt-4">
                        <h5>Load Files:</h5>
                        <form onSubmit={handleFormSubmit} className="form-inline">
                            <input type="hidden" name="actionName" value={actionName} />

                            <div className="form-group mb-3">
                                <label htmlFor="inputFile" className="form-label mr-2">Input File:</label>
                                <input
                                    type="file"
                                    className="form-control-file"
                                    id="inputFile"
                                    name="inputFile"
                                    required
                                    onChange={handleFileChange}
                                />
                            </div>

                            <div className="form-group mb-3">
                                <label htmlFor="inputContent" className="form-label">Input File Content:</label>
                                <textarea
                                    className="form-control"
                                    id="inputContent"
                                    rows="4"
                                    value={inputContent}
                                    readOnly
                                />
                            </div>

                            <div className="form-group mb-3">
                                <label htmlFor="outputContent" className="form-label">Result:</label>
                                <textarea
                                    className="form-control"
                                    id="outputContent"
                                    rows="4"
                                    value={outputContent}
                                    readOnly
                                />
                            </div>

                            <button type="submit" className="btn btn-outline-primary">Solve</button>
                        </form>
                    </section>
                </div>
            </div>
        </div>
    );
};

LabPage.propTypes = {
    labNumber: PropTypes.string.isRequired,
};

export default LabPage;
