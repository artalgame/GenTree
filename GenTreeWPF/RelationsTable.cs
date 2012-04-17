using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace GenTreeBE
{
    public class RelationsTable : IEnumerable<RelationBetweenTwoPerson>
    {
        public RelationBetweenTwoPerson this[int i]
        {
            get { return _relationsList[i]; }
            set { _relationsList[i] = value; }
        }

        private static RelationsTable _relationsTable=null;

        private List<RelationBetweenTwoPerson> _relationsList;

        public void Clear()
        {
            _relationsList = new List<RelationBetweenTwoPerson>();
        }
        public List<RelationBetweenTwoPerson> GetRelationList()
        {
            return _relationsList;
        }
        public  List<RelationBetweenTwoPerson> GetPersonRelation(Person person,bool onlyWherePersonIsFirst = true)
        {
            return (_relationsList.Where(x => x.FirstPerson.ID == person.ID)).ToList();
        }
        public static RelationsTable GetTable(List<RelationBetweenTwoPerson> relationList = null)
        {
            if (_relationsTable == null)
            {
                if (relationList == null)
                    _relationsTable =  new RelationsTable();
                else
                    _relationsTable =  new RelationsTable(relationList);
            }
            if (relationList != null)
                _relationsTable._relationsList = relationList;
            return _relationsTable;
        }
        private RelationsTable()
        {
            _relationsList = new List<RelationBetweenTwoPerson>();
        }
        private RelationsTable(List<RelationBetweenTwoPerson> list)
        {
            _relationsList = list;
        }
        public RelationBetweenTwoPerson GetRelationsBetweenPersons(Person firstPerson, Person secondPerson)
        {
            try
            {
                RelationBetweenTwoPerson answ = _relationsList.Where<RelationBetweenTwoPerson>(x => (x.FirstPerson == firstPerson)
                    && (x.SecondPerson == secondPerson)).Single<RelationBetweenTwoPerson>();
                return answ;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool SetRelationBetweenPersons(Person firstPerson, Person secondPerson, Relatives relation)
        {
            RelationBetweenTwoPerson tmp = GetRelationsBetweenPersons(firstPerson, secondPerson);
            try
            {
                if (tmp == null)
                {
                    RelationBetweenTwoPerson newRelation = new RelationBetweenTwoPerson(firstPerson, secondPerson, relation);
                    RelationBetweenTwoPerson newOppositeRelation = new RelationBetweenTwoPerson(secondPerson,firstPerson,GetOpositeRelative(relation,secondPerson));
                    _relationsList.Add(newRelation);
                    _relationsList.Add(newOppositeRelation);
                    return true;
                }
                else
                {
                    RelationBetweenTwoPerson relatives = _relationsList.Where<RelationBetweenTwoPerson>(x => (x.FirstPerson == firstPerson)
                     && (x.SecondPerson == secondPerson)).Single<RelationBetweenTwoPerson>();
                    relatives.Relations = relation;

                    RelationBetweenTwoPerson oppositeRelation = _relationsList.Where<RelationBetweenTwoPerson>(x => (x.FirstPerson == secondPerson)
                     && (x.SecondPerson == firstPerson)).Single<RelationBetweenTwoPerson>();
                    oppositeRelation.Relations = GetOpositeRelative(relation,secondPerson);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Relatives GetOpositeRelative(Relatives relatives, Person secondPerson)
        {
            switch (relatives)
            {
                case Relatives.aunt:
                    return (secondPerson.Gender == Genders.Male) ? Relatives.nephew : Relatives.niece;
                    break;
                case Relatives.uncle:
                    return (secondPerson.Gender == Genders.Male) ? Relatives.nephew : Relatives.niece;
                    break;
                case Relatives.grandfather:
                    return (secondPerson.Gender == Genders.Male) ? Relatives.grandson : Relatives.granddaughter;
                    break;
                case Relatives.grandmother:
                    return (secondPerson.Gender == Genders.Male) ? Relatives.grandson : Relatives.granddaughter;
                    break;
                case Relatives.brother:
                    return (secondPerson.Gender == Genders.Male) ? Relatives.brother : Relatives.sister;
                    break;
                case Relatives.sister:
                    return (secondPerson.Gender == Genders.Male) ? Relatives.brother : Relatives.sister;
                    break;
                case Relatives.daughter:
                    return (secondPerson.Gender == Genders.Male) ? Relatives.father : Relatives.mother;
                    break;
                case Relatives.son:
                    return (secondPerson.Gender == Genders.Male) ? Relatives.father : Relatives.mother;
                    break;
                case Relatives.father:
                    return (secondPerson.Gender == Genders.Male) ? Relatives.son : Relatives.daughter;
                    break;
                case Relatives.mother:
                    return (secondPerson.Gender == Genders.Male) ? Relatives.son : Relatives.daughter;
                    break;
                case Relatives.granddaughter:
                    return (secondPerson.Gender == Genders.Male) ? Relatives.grandfather : Relatives.grandmother;
                    break;
                case Relatives.grandson:
                    return (secondPerson.Gender == Genders.Male) ? Relatives.grandfather : Relatives.grandmother;
                    break;
                case Relatives.husband:
                    return (secondPerson.Gender == Genders.Male) ? Relatives.husband : Relatives.wife;
                    break;
                case Relatives.wife:
                    return (secondPerson.Gender == Genders.Male) ? Relatives.husband : Relatives.wife;
                    break;
                case Relatives.nephew:
                    return (secondPerson.Gender == Genders.Male) ? Relatives.uncle : Relatives.aunt;
                    break;
                case Relatives.niece:
                    return (secondPerson.Gender == Genders.Male) ? Relatives.uncle : Relatives.aunt;
                    break;
                case Relatives.NoRelative:
                    return (secondPerson.Gender == Genders.Male) ? Relatives.NoRelative : Relatives.NoRelative;
                    break;
                default: return Relatives.NoRelative;
            }
        }

        public void DeleteRelationOfPerson(Person person)
        {
            _relationsList.RemoveAll(x => (x.FirstPerson == person) || (x.SecondPerson == person));
        }
        public IEnumerator<RelationBetweenTwoPerson> GetEnumerator()
        {
            return _relationsList.GetEnumerator();
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _relationsList.GetEnumerator();
            throw new NotImplementedException();
        }
    }
}
