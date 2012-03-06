using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace GenTree
{
    public class RelationsTable : IEnumerable<RelationBetweenTwoPerson>
    {
        private List<RelationBetweenTwoPerson> _relationsList;

        public void Clear()
        {
            _relationsList = new List<RelationBetweenTwoPerson>();
        }
        public List<RelationBetweenTwoPerson> GetRelationList()
        {
            return _relationsList;
        }

        public static RelationsTable GetTable(List<RelationBetweenTwoPerson> relationList = null)
        {
            if (relationList == null)
                return new RelationsTable();
            else
                return new RelationsTable(relationList);
        }
        private RelationsTable()
        {
            _relationsList = new List<RelationBetweenTwoPerson>();
        }
        private RelationsTable(List<RelationBetweenTwoPerson> list)
        {
            _relationsList = list;
        }
        public Relatives GetRelationsBetweenPersons(Person firstPerson, Person secondPerson)
        {
            try
            {
                RelationBetweenTwoPerson answ = _relationsList.Where<RelationBetweenTwoPerson>(x => (x.FirstPerson == firstPerson)
                    && (x.SecondPerson == secondPerson)).Single<RelationBetweenTwoPerson>();
                return answ.Relations;
            }
            catch (Exception)
            {
                return Relatives.NoRelative;
            }
        }

        public bool SetRelationBetweenPersons(Person firstPerson, Person secondPerson, Relatives relation)
        {
            Relatives tmp = GetRelationsBetweenPersons(firstPerson, secondPerson);
            try
            {
                if (tmp == Relatives.NoRelative)
                {
                    RelationBetweenTwoPerson newRelation = new RelationBetweenTwoPerson(firstPerson, secondPerson, relation);
                    _relationsList.Add(newRelation);
                    return true;
                }
                else
                {
                    RelationBetweenTwoPerson answ = _relationsList.Where<RelationBetweenTwoPerson>(x => (x.FirstPerson == firstPerson)
                     && (x.SecondPerson == secondPerson)).Single<RelationBetweenTwoPerson>();
                    answ.Relations = relation;
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
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
