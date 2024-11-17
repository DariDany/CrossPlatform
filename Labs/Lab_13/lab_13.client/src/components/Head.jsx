import { Helmet } from 'react-helmet';

const Head = () => {
    return (
        <Helmet>
            <meta charSet="UTF-8" />
            <title>Welcome!</title>
            <meta name="description" content="��� ���������� �������� ���������� ��������� ������ 1, 2 � 3. ���� �����, ������ ��� �������������, ��� ������." />
            <meta name="viewport" content="width=device-width, initial-scale=1" />
        </Helmet>
    );
};

export default Head;