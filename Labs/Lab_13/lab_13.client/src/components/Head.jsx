import { Helmet } from 'react-helmet';

const Head = () => {
    return (
        <Helmet>
            <meta charSet="UTF-8" />
            <title>Welcome!</title>
            <meta name="description" content="Цей застосунок дозволяє виконувати практичні роботи 1, 2 і 3. Будь ласка, увійдіть або зареєструйтесь, щоб почати." />
            <meta name="viewport" content="width=device-width, initial-scale=1" />
        </Helmet>
    );
};

export default Head;