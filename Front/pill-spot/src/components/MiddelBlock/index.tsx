import { Row, Col } from "antd";
import { withTranslation } from "react-i18next";
import { TFunction } from "i18next";
import { Slide } from "react-awesome-reveal";
import { Button } from "../../UI/Button";
import { MiddleBlockSection, ContentWrapper } from "./styles";
import SearchMedicine from "../SearchMedicine";
import { useState } from "react";
import { useNavigate } from "react-router-dom";

interface MiddleBlockProps {
  title: string;
  content: string;
  button: string;
  t: TFunction;
}

const MiddleBlock = ({ title, button, t }: MiddleBlockProps) => {
  const [medecineToSearch, setMedecineSearch] = useState("");
  const nav = useNavigate();

  console.log(medecineToSearch);
  
  return (
    <div id="searchSection">
      <MiddleBlockSection>
        <Slide direction="up" triggerOnce>
          <Row justify="center" align="middle">
            <ContentWrapper>
              <Col lg={24} md={24} sm={24} xs={24}>
                <h6>{t(title)}</h6>
                <div className="m-10">
                  <SearchMedicine setMedecineSearch={setMedecineSearch} />
                </div>
                
                {button && (
                  <Button name="submit" onClick={()=>{nav(`/result?medecinetosearch=${encodeURIComponent(medecineToSearch)}`);}}>
                    {t(button)}
                  </Button>
                )}
              </Col>
            </ContentWrapper>
          </Row>
        </Slide>
      </MiddleBlockSection>
    </div>
  );
};

export default withTranslation()(MiddleBlock);
